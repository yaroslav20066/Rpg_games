using System.Collections.Generic;
using System.Data;
using System.Numerics;
using Unity.Collections;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
public class ItemInventory : MonoBehaviour
{
    public const int item_blank = 0;
    public const int item_podorozhnik = 1;
    public const int item_bandage = 2;
    public const int item_sugar = 3;
    public const int item_remedy = 4;
    public int[] hotbarSlots = {0,0,0,0,0};
    public PlayerStatsScript playerStats;
    public Movable movable;
    bool sugarActive = false, remedyActive = false;
    float sugarTimerLeft = 0, remedyTimerLeft = 0;
    const float sugarTimerMax = 30, remedyTimerMax = 60;

    void Update() 
    {
        if (playerStats.plantain <= 0) {
            hotbarSlots[1] = 0;
        }
        else {hotbarSlots[1] = 1;}

        if (playerStats.bandage <= 0) {
            hotbarSlots[2] = 0;
        }
        else {hotbarSlots[2] = 2;}

        if (playerStats.sugar <= 0) {
            hotbarSlots[3] = 0;
        }
        else {hotbarSlots[3] = 3;}

        if (playerStats.drag <= 0) {
            hotbarSlots[4] = 0;
        }
        else {hotbarSlots[4] = 4;}
    }
    public void consume(int slot)
    {
        if (slot == 1)
        {
            if (playerStats.plantain > 1) {
                processItemID(hotbarSlots[slot]);
            }
            else if (playerStats.plantain == 1) {
                hotbarSlots[slot] = 1;
                processItemID(hotbarSlots[slot]);
                hotbarSlots[slot] = 0;
            }
        }
        else if (slot == 2)
        {
            if (playerStats.bandage > 1) {
                processItemID(hotbarSlots[slot]);
            }
            else if (playerStats.bandage == 1) {
                hotbarSlots[slot] = 2;
                processItemID(hotbarSlots[slot]);
                hotbarSlots[slot] = 0;
            }
        }
        else if (slot == 3)
        {
            if (playerStats.sugar > 1) {
                processItemID(hotbarSlots[slot]);
            }
            else if (playerStats.sugar == 1) {
                hotbarSlots[slot] = 3;
                processItemID(hotbarSlots[slot]);
                hotbarSlots[slot] = 0;
            }
        }
        else if (slot == 4)
        {
            if (playerStats.drag > 1) {
                processItemID(hotbarSlots[slot]);
            }
            else if (playerStats.drag == 1) {
                hotbarSlots[slot] = 4;
                processItemID(hotbarSlots[slot]);
                hotbarSlots[slot] = 0;
            }
        }
        
    }
    public void processItemID(int itemID)
    {
        switch (itemID)
        {
            case item_podorozhnik: {
                playerStats.health += 15;
                playerStats.usePlaintain(1);
                break;
            }
            case item_bandage: {
                playerStats.health += 50;
                playerStats.useBandages(1);
                break;        
            }
            case item_sugar: {
                movable.speed += 1;
                playerStats.health += 10;
                sugarActive = true;
                sugarTimerLeft = sugarTimerMax;
                playerStats.useSugar(1);
                break;
            }
            case item_remedy: {
                playerStats.health = playerStats.maxHealth;
                playerStats.regenPerFrame += 0.02f;
                remedyActive = true;
                remedyTimerLeft = remedyTimerMax;
                playerStats.useDrag(1);
                break;
            }

            default: {break;}
        }
    }

    public void setItem(int slot, int id) {hotbarSlots[slot] = id;}
    void FixedUpdate()
    {
        if (sugarActive) {
            sugarTimerLeft -= Time.deltaTime;
            if (sugarTimerLeft <= 0) {
                sugarActive = false;
                movable.speed -= 1;
            }
        }

        if (remedyActive) {
            remedyTimerLeft -= Time.deltaTime;
            if (remedyTimerLeft <= 0) {
                remedyActive = false;
                playerStats.regenPerFrame -= 0.02f;
            }
        }
    }
}