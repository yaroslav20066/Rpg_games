using UnityEngine;

public class BowScript : MonoBehaviour
{
    public float damage = 30;
    private bool is_Attack_Ready = false;
    private float timeReload = 0f;
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

    public void Attack(bool attack)
    {
        if (!attack || playerStatsScript.Arrows <= 0) return;
        if (is_Attack_Ready)
        {
            is_Attack_Ready = false;
            playerStatsScript.Arrows -= 1;
            timeReload = 0;

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

    void Update()
    {
        timeReload += Time.deltaTime;
        if (timeReload >= 2.0f && !is_Attack_Ready)
        {
            is_Attack_Ready = true;
            Debug.Log("Shoot!");
        }
    }
}