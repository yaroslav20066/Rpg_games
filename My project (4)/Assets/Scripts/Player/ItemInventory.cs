using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using TMPro;
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
    public Counter cntrATK, cntrLV, cntrDEF, cntrREGEN, cntrCRIT, cntrSPEED, cntrMAXHP;
    public HUD mainHUD;
    public Movable movable;
    public TextMeshProUGUI itemDescTextbox;
    public GameObject equipmentTab, hotbarObject, hotbarActiveOverlay;
    UnityEngine.Vector3 originalHotbarPosition, newHotbarPosition;
    int originalHotbarSortingOrder;
    bool sugarActive = false, remedyActive = false;
    float sugarTimerLeft = 0, remedyTimerLeft = 0;
    const float sugarTimerMax = 30, remedyTimerMax = 60;
    bool inventoryOpen;

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
                playerStats.getBandages(-1);
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
    public void Show() {
        equipmentTab.SetActive(true);
        inventoryOpen = true;

        equipmentTab.GetComponent<Canvas>().overrideSorting = true;
        equipmentTab.GetComponent<Canvas>().sortingOrder = 0;
        
        hotbarObject.GetComponent<Canvas>().overrideSorting = true;
        originalHotbarSortingOrder = hotbarObject.GetComponent<Canvas>().sortingOrder;
        hotbarObject.GetComponent<Canvas>().sortingOrder = 1;

        originalHotbarPosition = hotbarObject.GetComponent<RectTransform>().position;
        newHotbarPosition = originalHotbarPosition;
        newHotbarPosition.y += 64;

        hotbarObject.GetComponent<RectTransform>().position = newHotbarPosition;
    }

    public void Hide() {
        equipmentTab.SetActive(false);
        inventoryOpen = false;

        hotbarObject.GetComponent<Canvas>().overrideSorting = false;
        hotbarObject.GetComponent<Canvas>().sortingOrder = originalHotbarSortingOrder;

        hotbarObject.GetComponent<RectTransform>().position = originalHotbarPosition;
    }
    void Start()
    {

    }
    public void setItem(int slot, int id) {hotbarSlots[slot] = id;}

    String tmp;
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
        if (inventoryOpen) {
            itemDescTextbox.text = getDescByID(hotbarSlots[mainHUD.hotbarSelectedSlot]);
            cntrATK.value = playerStats.sword.base_damage;
            cntrDEF.value = playerStats.defense;
            cntrCRIT.value = playerStats.sword.crit;
            cntrREGEN.value = playerStats.regenPerFrame * 10;
            cntrSPEED.value = movable.speed*10;
            cntrLV.value = playerStats.LevelCounter.value;
            cntrMAXHP.value = playerStats.maxHealth;
        }
    }

    String getDescByID(int itemID) {
        switch (itemID)
        {
            case ItemInventory.item_bandage: return "Повязка\nВосстанавливает 50 HP";
            case ItemInventory.item_podorozhnik: return "Подорожник\nВосстанавливает 15 HP";
            case ItemInventory.item_sugar: return "Сахар\nВосстанавливает 10 HP\nУвеличивает скорость на 30 секунд";
            case ItemInventory.item_remedy: return "Снадобье\nВосстанавливает все HP\nУсиливает регенерацию на 60 секунд";
            default: return "Выберите предмет чтобы увидеть\nего описание";
        }
    }
}