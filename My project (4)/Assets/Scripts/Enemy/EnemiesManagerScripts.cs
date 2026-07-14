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
                EnemySoldierScript enemySoldierScript = enemies[i].GetComponent<EnemySoldierScript>();
                enemySoldierScript.enabled = true;
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
