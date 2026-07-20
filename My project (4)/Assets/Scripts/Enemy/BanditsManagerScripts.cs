using UnityEngine;

public class BanditsManagerScripts : MonoBehaviour
{
    public MainGoalCounter mainGoal;
    public PlayerStatsScript playerStatsScript;
    public GameObject[] enemies;

    public AudioSource audioSource;
    public AudioClip music_calm;
    public AudioClip music_fight;

    void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].SetActive(true);
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
        if (nul == enemies.Length)
        {
            audioSource.Stop();
            audioSource.clip = music_calm;
            audioSource.Play();

            mainGoal.NewTraderStep();
            playerStatsScript.TakeExperienceFromQuest(100);
            Destroy(this);
        }
    }
}
