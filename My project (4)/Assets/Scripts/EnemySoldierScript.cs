using UnityEngine;
using System.Collections.Generic;
using Unity.AI;
using UnityEngine.AI;

public class EnemySoldierScript : MonoBehaviour {
    Transform target;
    NavMeshAgent agent;
    public float lookRadius;
    public float rotationSpeed = 5f;
    public float timeReload = 0f;
    public float health = 100f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        agent = GetComponent<NavMeshAgent>();
        target = PlayerManager.instance.player.transform;        
    }

    // Update is called once per frame
    void Update(){
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius) {
            agent.SetDestination(target.position);
            if (distance <= agent.stoppingDistance)
            {
                if (timeReload >= 5f) {
                    PlayerStatsScript.instance.TakeDamage(25);
                    timeReload = 0f;
                }
                lookTarget();
            }
        }
        timeReload += 0.1f;
    }
    void lookTarget() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public void TakeDamage(float damage) {
        health -= damage;
        if (health <= 0) {

            Loot loot = this.GetComponent<Loot>();
            loot.lootEnemies();

            Destroy(gameObject);
        }
    }
}
