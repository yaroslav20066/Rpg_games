using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float damage = 25;
    public float crit = 0;
    public float attackRange = 7.0f;
    public float sphereRadius = 1.5f; 
    public float sphereDistance = 2.0f; 
    
    private float timeReload = 0f;

    public void Attack(bool attack)
    {   
        if (!attack) return;
        
        if (timeReload >= 2.5f)
        {
            Vector3 spherePosition = transform.position + transform.forward * sphereDistance;
            

            Collider[] hitColliders = Physics.OverlapSphere(spherePosition, sphereRadius);
            
            foreach (Collider collider in hitColliders)
            {
                EnemySoldierScript soldier = collider.GetComponent<EnemySoldierScript>();
                if (soldier != null)
                {
                    soldier.TakeDamage(damage);
                    Debug.Log("Hit: " + collider.name);
                    if (Random.Range(0, 1) < crit)
                    {
                        soldier.TakeDamage(damage);
                    }
                }
            }
            
            timeReload = 0f;
        }
    }

    void Update()
    {
        timeReload += Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        Vector3 spherePosition = transform.position + transform.forward * sphereDistance;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(spherePosition, sphereRadius);
    }

    public void updateCrit()
    {
        crit += 0.25f;
    }
}