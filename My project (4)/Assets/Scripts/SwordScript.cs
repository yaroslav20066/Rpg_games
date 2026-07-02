using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float damage = 20;
    public float heavy_damage = 40;
    public float crit = 0;
    public float heavy_crit = 0;
    public float sphereRadius = 1.5f; 
    public float sphereDistance = 2.0f; 
    private bool is_Attack_Ready = false;
    private bool is_Heavy_Attack_Ready = false;
    private bool heavy_attack_allowed = false;
    
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
        
        if (is_Attack_Ready)
        {
            is_Attack_Ready = false;
            is_Heavy_Attack_Ready = false;
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
    public void Heavy_Attack(bool attack)
    {
        if (!attack || !heavy_attack_allowed) return;

        if (is_Heavy_Attack_Ready)
        {
            is_Attack_Ready = false;
            is_Heavy_Attack_Ready = false;
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
                        soldier.TakeDamage(heavy_damage);
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
        if (timeReload >= 1 && !is_Attack_Ready)
        {
            is_Attack_Ready = true;
            Debug.Log("Attack Ready");
        }
        if (timeReload >= 2.5 && !is_Heavy_Attack_Ready && heavy_attack_allowed)
        {
            is_Heavy_Attack_Ready = true;
            Debug.Log("Heavy Attack Ready");
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

    public void updateCrit() {
        crit += 0.25f;
        heavy_crit += 0.45f;
    }

    public void updateDamage() {
        heavy_attack_allowed = true;
    }
}