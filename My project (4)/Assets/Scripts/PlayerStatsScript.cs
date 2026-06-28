using UnityEngine;

public class PlayerStatsScript : MonoBehaviour
{
    public static PlayerStatsScript instance;
    public float health = 100;
    public float experience = 0;

    void Awake()
    {
        instance = this;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0){
            Debug.Log("You are dead");
        }
    }

    public void TakeExperience(float exp)
    {
        experience += exp;
    }
}
