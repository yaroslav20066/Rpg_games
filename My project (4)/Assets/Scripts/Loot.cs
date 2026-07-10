using UnityEngine;

public class Loot : MonoBehaviour
{
    public PlayerStatsScript playerStatsScript;
    public int silver;
    public int arrow;
    public int armor;
    public bool ticket;
    public float experience;
    public void lootEnemies()
    {
        playerStatsScript.getArrow(arrow);
        playerStatsScript.getSilver(silver);
        playerStatsScript.TakeExperience(experience);
        playerStatsScript.getTicket(ticket);
        playerStatsScript.getArmor(armor);
    }
}
