using Unity.VisualScripting;
using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public float damage = 25;
    private float timeReload = 0f;
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }
    public void Attack(bool attack)
    {
        if (timeReload >= 5f)
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 4.0f) && attack)
            {
                EnemySoldierScript soldier = hit.transform.GetComponent<EnemySoldierScript>();
                if(soldier != null)
                {
                    Debug.Log("Got Damage");
                    soldier.TakeDamage(damage);
                }
                timeReload = 0f; 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeReload += 0.1f;
    }
}
