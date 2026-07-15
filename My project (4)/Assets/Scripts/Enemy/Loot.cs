using UnityEngine;

public class Loot : MonoBehaviour
{
    GameObject target;
    PlayerStatsScript playerStatsScript;
    public int silver;
    public int arrow;
    public bool ticket;
    public float experience;

    void Start() {
        target = PlayerManager.instance.player;
        playerStatsScript = target.GetComponent<PlayerStatsScript>();
    }
    public void lootEnemies()
    {
        playerStatsScript.getArrow(arrow);
        playerStatsScript.getSilver(silver);
        playerStatsScript.TakeExperience(experience);
        playerStatsScript.getTicket(ticket);
    }
}
