using System;
using UnityEngine;

public class EnemiesManagerScripts : MonoBehaviour
{
    public GameObject[] enemies;

    void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(true);
            EnemySoldierScript script = enemies[i].GetComponent<EnemySoldierScript>();
            script.enabled = true;
        } 
    }
}
