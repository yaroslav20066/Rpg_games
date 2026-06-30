using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float damage = 25;
    public float crit = 0;
    public float sphereRadius = 1.5f; 
    public float sphereDistance = 2.0f; 
    private bool is_Attack_Ready = false;
    
    private float timeReload = 0f;
    private Camera playerCamera;
    Vector3 spherePosition;
    Collider[] hitColliders;

    void Start()
    {
        playerCamera = Camera.main;
        if (playerCamera == null)
        {
            playerCamera = GetComponentInChildren<Camera>();
        }

    }

    public void Attack(bool attack)
    {   
        if (!attack) return;
        
        if (is_Attack_Ready && attack)
        {
            is_Attack_Ready = false;
            timeReload = 0;
            
            if (hitColliders != null)
            {
                foreach (Collider collider in hitColliders)
                {
                    Debug.Log(hitColliders.Length);
                    Debug.Log(collider.GetType());
                    if (collider.GetComponent<EnemySoldierScript>() != null)
                    {
                        EnemySoldierScript soldier = collider.GetComponent<EnemySoldierScript>();
                        soldier.TakeDamage(damage);
                        Debug.Log("Hit: " + collider.name);
                        if (Random.Range(0f, 1f) < crit) 
                        {
                            soldier.TakeDamage(damage);
                        }
                    }
                }
            }
        }
    }

    void Update()
    {
        timeReload += Time.deltaTime;
        if (timeReload >= 2.5 && !is_Attack_Ready)
        {
            is_Attack_Ready = true;
            Debug.Log("Attack Ready");
        }
        spherePosition = transform.position + playerCamera.transform.forward * sphereDistance;
        hitColliders = Physics.OverlapSphere(spherePosition, sphereRadius);
    }

    void OnDrawGizmos()
    {
        Vector3 spherePosition;

        if (playerCamera != null)
        {
            spherePosition = transform.position + playerCamera.transform.forward * sphereDistance;
        }
        else
        {
            spherePosition = transform.position + transform.forward * sphereDistance;
        }

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spherePosition, sphereRadius);
    }

    public void updateCrit()
    {
        crit += 0.25f;
    }
}