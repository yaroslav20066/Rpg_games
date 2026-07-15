using System;
using UnityEngine;

public class EnemiesManagerScripts : MonoBehaviour
{
    public GameObject[] enemies;

    void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null) {
                enemies[i].SetActive(true);
            }
        } 
    }

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
    public void Leave() {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i] != null) {
                Destroy(enemies[i]);
            }
        } 
    }
}
