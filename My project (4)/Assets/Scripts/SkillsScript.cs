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
    public Button lier;
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
        lier.onClick.AddListener(Lier);
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
            points.skillPointsCounter.value -= 1;
            arrow.interactable = false;
            aim.interactable = true;
        }
    }

    void Speed()
    {
        if (points.skillPointsCounter.value > 0)
        {
            player_movable.updateSpeed();
            points.skillPointsCounter.value -= 1;
            speed.interactable = false;
            lier.interactable = true;
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

    void Lier()
    {
        if (points.skillPointsCounter.value > 0)
        {
            player_movable.updateCrouchMultiplier();
            points.skillPointsCounter.value -= 1;
            lier.interactable = false;
        }
    }
}
