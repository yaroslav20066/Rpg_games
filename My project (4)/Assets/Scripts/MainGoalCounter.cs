using TMPro;
using UnityEngine;

public class MainGoalCounter : MonoBehaviour
{
    public string defaultText;
    public TextMeshProUGUI main_goal;
    public GameObject player;
    PlayerStatsScript silver;
    public int step = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        silver = player.GetComponent<PlayerStatsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (step == 1)
        {
            main_goal.text = defaultText + " Get to the bridge";
        }
        else if (step == 2)
        {
            main_goal.text = defaultText + " " + silver.silver + " / 750 silver";
            if (silver.silver >= 1000)
            {
                main_goal.text = defaultText + "come back to the guards";
            }
        }
        
    }
    public void NewStep()
    {
        step += 1;
    }
}
