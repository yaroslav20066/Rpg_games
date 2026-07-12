using UnityEngine;

public class BanditsManagerScripts : MonoBehaviour
{
    public MainGoalCounter mainGoal;
    public PlayerStatsScript playerStatsScript;
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

    void Update()
    {
        int nul = 0;
        for (int i = 0; i < enemies.Length; i++)    {
            if (enemies[i] == null) {
                nul += 1;
            }
        }
        if (nul == 4)
        {
            mainGoal.NewTraderStep();
            playerStatsScript.TakeExperience(100);
            Destroy(this);
        }
    }
}
