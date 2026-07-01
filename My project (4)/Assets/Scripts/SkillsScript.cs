using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class SkillsScript : MonoBehaviour
{
    public Button crit;
    public Button arrow;
    public Button speed;
    public Button heavy_attack;
    public Button aim;
    public Button smooth_talker;
    public GameObject player;
    Movable player_movable; 
    SwordScript sword;
    PlayerStatsScript points;
    
    void Start()
    {
        player_movable = player.GetComponent<Movable>();
        sword = player.GetComponent<SwordScript>();
        points = player.GetComponent<PlayerStatsScript>();

        crit.onClick.AddListener(Crit);
        arrow.onClick.AddListener(Arrow);
        speed.onClick.AddListener(Speed);
        heavy_attack.onClick.AddListener(HeavyAttack);
        aim.onClick.AddListener(Aim);
        smooth_talker.onClick.AddListener(Smooth_talker);
    }

    void Crit()
    {
        if (points.skillPointsCounter.value > 0)
        {
            sword.updateCrit();
            points.skillPointsCounter.value -= 1;
            crit.interactable = false;
            heavy_attack.interactable = true;
        }
    }
    void Arrow()
    {
        if (points.skillPointsCounter.value > 0)
        {
            // что то сделать с луком
            points.updateArrows();
            points.skillPointsCounter.value -= 1;
            arrow.interactable = false;
        }
    }

    void Speed()
    {
        if (points.skillPointsCounter.value > 0)
        {
            player_movable.updateSpeed();
            points.skillPointsCounter.value -= 1;
            speed.interactable = false;
            smooth_talker.interactable = true;
        }
    }

    void HeavyAttack()
    {
        if (points.skillPointsCounter.value > 0)
        {
            sword.updateDamage();
            points.skillPointsCounter.value -= 1;
            heavy_attack.interactable = false;
        }
    }

    void Aim()
    {
        if (points.skillPointsCounter.value > 0)
        {
            // что то ещё с луком
            points.skillPointsCounter.value -= 1;
            aim.interactable = false;
        }
    }

    void Smooth_talker()
    {
        if (points.skillPointsCounter.value > 0)
        {
            player_movable.updateCrouchMultiplier();
            points.skillPointsCounter.value -= 1;
            smooth_talker.interactable = false;
        }
    }
}
