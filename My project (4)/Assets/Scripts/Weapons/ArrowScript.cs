using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    public float speed = 10.0f;
    private float arrow_damage = 0;
    
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    
    void OnTriggerEnter(Collider other) 
    {
        Debug.Log("In");
        EnemySoldierScript enemy = other.GetComponent<EnemySoldierScript>();
        if (enemy != null)
        {
            enemy.TakeDamage(arrow_damage);
        }
        Destroy(this.gameObject);
    }
    
    public void giveDamage(float damage)
    {
        arrow_damage = damage;
    }
}