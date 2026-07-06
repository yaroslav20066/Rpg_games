using UnityEngine;

public class BowScript : MonoBehaviour
{
    public float damage = 30;
    public Counter cooldownCounter;
    public float cooldown = 1f;
    private Camera playerCamera;
    PlayerStatsScript playerStatsScript;
    [SerializeField] GameObject arrowPrefab;
    private GameObject arrow;
    
    void Start()
    {
        playerCamera = Camera.main;
        if (playerCamera == null)
        {
            playerCamera = GetComponentInChildren<Camera>();
        }
        playerStatsScript = GetComponent<PlayerStatsScript>();
    }

    void FixedUpdate()
    {
        cooldownCounter.value += Time.fixedDeltaTime;
    }

    public void Attack(bool attack)
    {
        if (!attack || playerStatsScript.Arrows <= 0) return;
        if (cooldownCounter.isFull())
        {
            playerStatsScript.Arrows--;
            cooldownCounter.value = 0;
            cooldownCounter.maxValue = cooldown;

            Vector3 spawnArrow = Vector3.forward * 1.5f;
            spawnArrow.y += 0.5f;
            arrow = Instantiate(arrowPrefab, 
            transform.TransformPoint(spawnArrow), 
            playerCamera.transform.rotation) as GameObject;
        
            ArrowScript arr_dm = arrow.GetComponent<ArrowScript>();
            if (arr_dm != null)
            {
                arr_dm.giveDamage(damage);
            } 
            
            
        }
    }
}