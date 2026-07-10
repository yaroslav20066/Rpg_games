using System;
using UnityEngine;

public class PlayerStatsScript : MonoBehaviour
{
    public static PlayerStatsScript instance;
    public float maxHealth = 100;
    public float health = 100;
    public float defense = 5;
    public int armor = 0;
    public float experience = 0;
    public float nextLevelMultiplier;

    public Counter expCounter;
    public HUD currentHUD;
    public Counter skillPointsCounter;
    public Counter LevelCounter;
    public float lastHit = 0f;
    public float regenStartsAfter = 1.5f;
    public float regenPerFrame = 0.1f;
    Movable movement;
    public SwordScript sword;
    float newEXP;
    public bool bonus = false;

    public bool ticket = false;

    // инвентарь
    public int maxArrows = 6;
    public int Arrows = 3;
    public int silver = 0;
    public int bandage = 0;
    public int plantain = 1;
    public int sugar = 1;
    public int drag = 1;

    void Awake() {
        instance = this;
        movement = GetComponent<Movable>();
        sword = GetComponent<SwordScript>();
    }

    private void Update() {
        expCounter.value = experience;
        if (expCounter.isFull()) {
            experience -= expCounter.maxValue;
            expCounter.maxValue = (float)(Math.Floor  ((expCounter.maxValue*nextLevelMultiplier)/10)) * 10;
            skillPointsCounter.value++;
            sword.base_damage += 5;
            sword.base_heavy_damage += 10;
            defense += 2;
            maxHealth += 10;
            health += 10;
            LevelCounter.value++;
            currentHUD.XPmessage(newEXP, true);
            newEXP = 0;
        } 
        else if (newEXP > 0) {
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

    public void TakeDamage(float damage) {
        damage -= defense;
        if (damage > 0) {
            health -= damage;
            lastHit = Time.time;
            if (health <= 0){
            }
        }
    }

    public void TakeExperience(float exp) {
        experience += exp;
        newEXP = exp;
    }
    public void updateArrows() {
        maxArrows += 6;
    }

    public void updateRegen() {
        regenPerFrame *= 1.5f;
        regenStartsAfter -= 0.5f;
    }

    public void updateSmoothTalker() {
        bonus = true;
    }


    public void getBandages(int stuff)
    {
        if (stuff == 0) return;

        bandage += stuff;
        Debug.Log("Получено: " + stuff + " повязка");
    }

    public void useBandages(int stuff)
    {
        if (stuff == 0) return;

        bandage -= stuff;
        Debug.Log("Вы использовали " + stuff + " повязку");
    }

    public void getPlantain(int stuff)
    {
        if (stuff == 0) return;

        plantain += stuff;
        Debug.Log("Получено: " + stuff + " подорожник");
    }

    public void usePlaintain(int stuff)
    {
        if (stuff == 0) return;

        plantain -= stuff;
        Debug.Log("Вы использовали " + stuff + " подорожник");
    }

    public void getSugar(int stuff)
    {
        if (stuff == 0) return;

        sugar += stuff;
        Debug.Log("Получено: " + stuff + " сахар");
    }

    public void useSugar(int stuff)
    {
        if (stuff == 0) return;

        sugar -= stuff;
        Debug.Log("Вы использовали " + stuff + " сахар");
    }

    public void getDrag(int stuff)
    {
        if (stuff == 0) return;

        drag += stuff;
        Debug.Log("Получено: " + stuff + " снадобье");
    }
    public void useDrag(int stuff)
    {
        if (stuff == 0) return;

        drag -= stuff;
        Debug.Log("Вы использовали " + stuff + " снадобье");
    }

    public void getArrow(int stuff)
    {
        if (stuff == 0) return;

        Arrows += stuff;
        Debug.Log("Получено: " + stuff + " стрел");
        if (Arrows >= maxArrows)
        {
            Arrows = maxArrows;
            Debug.Log("Переполнение инвентаря!");
        }
    }

    public void getSilver(int stuff)
    {
        if (stuff == 0) return;

        silver += stuff;
        Debug.Log("Получено: " + stuff + " серебра");
    }

    public void getTicket(bool stuff) {
        ticket = stuff;
    }

    public void getArmor(int stuff)
    {
        armor += stuff;
    }
}
