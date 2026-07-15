using UnityEngine;

public class SoldiersManagerScript : MonoBehaviour
{
    public GameObject[] enemies;
    private float timeAfter = 5f;
    private bool isGameEnding = false;

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
            if (timeAfter <= 0)
            {
                #if UNITY_EDITOR
                    UnityEditor.EditorApplication.isPlaying = false;
                #else
                    Application.Quit();
                #endif
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
    }
}
