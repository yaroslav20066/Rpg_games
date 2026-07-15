using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float speed = 10.0f;
    private float arrow_damage = 0;
    
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other)  {
        EnemySoldierScript enemy = other.GetComponent<EnemySoldierScript>();
        EnemyArcherScript archer_enemy = other.GetComponent<EnemyArcherScript>();
        PlayerStatsScript player = other.GetComponent<PlayerStatsScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(arrow_damage);
        }
        else if (archer_enemy != null)
        {
            archer_enemy.TakeDamage(arrow_damage);
        }
        else if (player != null)
        {
            player.TakeDamage(arrow_damage);
        }
        
        Destroy(this.gameObject);
    }
    
    public void giveDamage(float damage)
    {
        arrow_damage = damage;
    }
}