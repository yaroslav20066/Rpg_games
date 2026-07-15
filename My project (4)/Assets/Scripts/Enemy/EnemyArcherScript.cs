using UnityEngine;
using UnityEngine.UI;

public class EnemyArcherScript : MonoBehaviour
{
    Transform target;

    public float lookRadius;
    public float damage_enemy = 25;
    public float rotationSpeed = 5f;
    public float timeReload = 0f;
    [SerializeField] private float health = 100f;
    private float Maxhealth;
    public Canvas canvas;
    public Image bar;

    [SerializeField] GameObject arrowPrefab;
    private GameObject arrow;

    void Start() {
        canvas.gameObject.SetActive(true);

        Maxhealth = health;
        target = PlayerManager.instance.player.transform;       
    }

    void Update() {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius) 
        {
            lookTarget();
            if (timeReload >= 5f && distance > 5f) {
                Shoot();
                timeReload = 0f;
            }
        }
        timeReload += Time.deltaTime;
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

    public void Shoot()
    {
         Vector3 spawnArrow = Vector3.forward * 1.5f;
        spawnArrow.y += 0.5f;
        arrow = Instantiate(arrowPrefab, 
            transform.TransformPoint(spawnArrow), 
            Quaternion.LookRotation(target.position - transform.position)) as GameObject;
    
        ArrowScript arr_dm = arrow.GetComponent<ArrowScript>();
        if (arr_dm != null)
        {
            arr_dm.giveDamage(damage_enemy);
        } 
    }

    public void TakeDamage(float damage) {
        if (enabled) {
            health -= damage;

            bar.fillAmount = ((health * 100) / Maxhealth ) / 100;

            if (health <= 0) {

                Loot loot = this.GetComponent<Loot>();
                loot.lootEnemies();

                Destroy(gameObject);
            }
        }
    }
}
