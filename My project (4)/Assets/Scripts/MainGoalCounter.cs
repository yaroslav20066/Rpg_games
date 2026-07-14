using TMPro;
using UnityEngine;

public class MainGoalCounter : MonoBehaviour
{
    public string defaultText;
    public TextMeshProUGUI main_goal;
    public GameObject player;
    PlayerStatsScript silver;
    [HideInInspector] public int step = 1;
    [HideInInspector] public int step_priest = 1;
    [HideInInspector] public int step_trader = 1;
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
            main_goal.text = defaultText + " Идите к мосту";
        }
        else if (step == 2)
        {
            main_goal.text = defaultText + " " + silver.silver + " / 750 серебра";
            if (silver.silver >= 750)
            {
                main_goal.text = defaultText + "Возвращайтесь к охране";
            }
        }
        
    }
    public void NewStep() {
        step += 1;
    }

    public void NewPriestStep() {
        step_priest += 1;
    }

    public void NewTraderStep() {
        step_trader += 1;
    }
}
