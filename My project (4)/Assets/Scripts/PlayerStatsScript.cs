using System;
using UnityEngine;

public class PlayerStatsScript : MonoBehaviour
{
    public static PlayerStatsScript instance;
    public float maxHealth = 100;
    public float health = 100;
    public float experience = 0;
    public float nextLevelMultiplier;

    public Bar expBar;
    public HUD currentHUD;
    public Counter skillPointsCounter;
    public Counter LevelCounter;
    public float lastHit = 0f;
    public float regenStartsAfter = 1.5f;
    public float regenPerFrame = 0.1f;
    Movable movement;
    SwordScript sword;
    bool regen;
    float newEXP;

    // инвентарь
    public int maxArrows = 6;
    public int Arrows = 3;

    void Awake()
    {
        instance = this;
        movement = GetComponent<Movable>();
        sword = GetComponent<SwordScript>();
    }

    private void Update()
    {
        expBar.value = experience;
        if (expBar.full())
        {
            experience -= expBar.maxValue;
            expBar.maxValue = (float)(Math.Floor  ((expBar.maxValue*nextLevelMultiplier)/10)) * 10;
            skillPointsCounter.value++;
            movement.speed++;
            movement.shiftedSpeed++;
            sword.base_damage += 5;
            sword.base_heavy_damage += 10;
            maxHealth += 10;
            health += 10;
            LevelCounter.value++;
            currentHUD.XPmessage(newEXP, true);
            newEXP = 0;
        } else if (newEXP > 0) {
            currentHUD.XPmessage(newEXP, false);
            newEXP = 0;
        }
    }

    private void FixedUpdate()
    {
        if (Time.time - lastHit > regenStartsAfter) { //регенерация начинается только через 1.5 секунды после последнего удара (1сек со скиллом)
            health += regenPerFrame;
        
            if (health >= maxHealth) {
            health = maxHealth;
            }
        }
    }


    public void TakeDamage(float damage)
    {
        health -= damage;
        lastHit = Time.time;
        if (health <= 0){
        }
        
    }

    public void TakeExperience(float exp)
    {
        experience += exp;
        newEXP = exp;
    }
    public void updateArrows()
    {
        maxArrows += 6;
    }

    public void updateRegen()
    {
        regenPerFrame *= 1.5f;
        regenStartsAfter -= 0.5f;
    }
}
