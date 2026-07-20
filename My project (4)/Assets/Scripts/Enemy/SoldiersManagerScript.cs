using UnityEngine;

public class SoldiersManagerScript : MonoBehaviour
{
    public GameObject[] enemies;
    private float timeAfter = 5f;
    private bool isGameEnding = false;
    public PlayerInputListener playerInputListener;

    public void ActivateEnemies() {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null) {
                enemies[i].SetActive(true);
                if (enemies[i].GetComponent<EnemySoldierScript>() != null) {
                    EnemySoldierScript enemySoldierScript = enemies[i].GetComponent<EnemySoldierScript>();
                    enemySoldierScript.enabled = true;
                }
                else if (enemies[i].GetComponent<EnemyArcherScript>() != null) {
                    EnemyArcherScript enemyArcherScript = enemies[i].GetComponent<EnemyArcherScript>();
                    enemyArcherScript.enabled = true;
                }
            }
        } 
    }

    void Update()
    {
        if (isGameEnding) {
            timeAfter -= Time.deltaTime;
            Debug.Log("time" + timeAfter);
            if (timeAfter <= 0)
            {
                playerInputListener.ending(EndingScript.ending_warrior);
            }
            return;
        }

        int num = 0;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] == null) {
                num += 1;
            }
        }
        if (num == enemies.Length) {
            isGameEnding = true;
        }
    }
}
