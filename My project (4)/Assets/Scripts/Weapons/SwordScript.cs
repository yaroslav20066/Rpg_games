using Unity.VisualScripting;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float base_damage = 20;
    public float base_heavy_damage = 40;
    public float crit = 0.04f;
    public float heavy_crit = 0;
    public float sphereRadius = 1.5f; 
    public float sphereDistance = 2.0f; 
    //public CooldownBar cooldownBar;
    public CooldownBar cooldownBar;
    private bool heavy_attack_allowed = false;

    private float base_attack_cooldown = 1f;
    private float base_heavy_attack_cooldown = 2.5f;
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
        if (cooldownBar.cooldownFinished()) {
        
            cooldownBar.beginCountdown(base_attack_cooldown);
        
        {
            if (hitColliders != null)
            {
                foreach (Collider collider in hitColliders)
                {
                    Debug.Log(collider.GetType());
                    if (collider.GetComponent<EnemySoldierScript>() != null)
                    {
                        EnemySoldierScript soldier = collider.GetComponent<EnemySoldierScript>();
                        soldier.TakeDamage(base_damage);
                        Debug.Log("Hit: " + collider.name);
                        if (Random.Range(0f, 1f) < crit) 
                        {
                            soldier.TakeDamage(base_damage);
                        }
                        cooldownBar.SetBarColor(Color.red); //показать что удар прошёл
                    }
                }
            }
        }
        }
    }
    public void Heavy_Attack(bool attack)
    {
        if (!attack || !heavy_attack_allowed) return;

        if (cooldownBar.cooldownFinished())
        {
            cooldownBar.beginCountdown(base_heavy_attack_cooldown);

            if (hitColliders != null)
            {
                foreach (Collider collider in hitColliders)
                {
                    Debug.Log(collider.GetType());
                    if (collider.GetComponent<EnemySoldierScript>() != null)
                    {
                        EnemySoldierScript soldier = collider.GetComponent<EnemySoldierScript>();
                        soldier.TakeDamage(base_heavy_damage);
                        Debug.Log("Hit: " + collider.name);
                        if (Random.Range(0f, 1f) < crit) 
                        {
                            soldier.TakeDamage(base_damage);
                        }
                        cooldownBar.SetBarColor(Color.red); //показать что удар прошёл
                    }
                }
            }
        }
    }

    void Update()
    {
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

    public void enableHeavyAttack() {
        heavy_attack_allowed = true;
    }
}