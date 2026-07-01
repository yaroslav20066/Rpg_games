using UnityEngine;

public class PlayerStatsScript : MonoBehaviour
{
    public static PlayerStatsScript instance;
    public float health = 100;
    public float experience = 0;
    public float nextLevelMultiplier;
    public Bar expBar;
    public Counter skillPointsCounter;

    // инвентарь
    public int maxArrows = 6;
    public int Arrows = 3;

    void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        expBar.value = experience;
        if (expBar.full())
        {
            experience -= expBar.maxValue;
            expBar.maxValue *= nextLevelMultiplier;
            skillPointsCounter.value++;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0){
        }
    }

    public void TakeExperience(float exp)
    {
        experience += exp;
    }
    public void updateArrows()
    {
        maxArrows += 6;
    }
}
