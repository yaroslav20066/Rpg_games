using UnityEngine;
using UnityEngine.UI;

public class SkillsScript : MonoBehaviour
{
    public Button crit;
    public Button arrow;
    public Button speed;
    public Button heavy_attack;
    public Button aim;
    public Button lier;
    public GameObject player;
    Movable player_speed; 
    SwordScript sword;
    PlayerStatsScript points;

    
    void Start()
    {
        player_speed = player.GetComponent<Movable>();
        sword = player.GetComponent<SwordScript>();
        points = player.GetComponent<PlayerStatsScript>();
        crit.onClick.AddListener(Crit);
        arrow.onClick.AddListener(Arrow);
        speed.onClick.AddListener(Speed);
    }

    void Crit()
    {
        if (points.skillPointsCounter.value > 0)
        {
            sword.updateCrit();
        }
    }
    void Arrow()
    {
        
    }

    void Speed()
    {
        if (points.skillPointsCounter.value > 0)
        {
            player_speed.updateSpeed();
        }
    }
}
