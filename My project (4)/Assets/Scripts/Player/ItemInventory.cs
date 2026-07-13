using System;
using System.Collections.Generic;
using System.Data;
using System.Numerics;
using TMPro;
using Unity.Collections;
using Unity.VisualScripting;
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
    public Button toggleChestplate, toggleHelmet, toggleBoots, toggleLeggings;
    public TextMeshProUGUI labelChestplate, labelHelmet, labelBoots, labelLeggings;
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

    }
    public void consume(int slot)
    {
        processItemID(hotbarSlots[slot]);
        hotbarSlots[slot] = item_blank;
    }
    public void processItemID(int itemID)
    {
        switch (itemID)
        {
            case item_podorozhnik: {
                playerStats.TakeHP(15);
                playerStats.usePlaintain(1);
                break;
            }
            case item_bandage: {
                playerStats.TakeHP(50);
                playerStats.getBandages(-1);
                break;        
            }
            case item_sugar: {
                movable.speed += 1;
                playerStats.TakeHP(10);
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
        toggleBoots.onClick.AddListener(ToggleBoots);
        toggleHelmet.onClick.AddListener(ToggleHelmet);
        toggleChestplate.onClick.AddListener(ToggleChestplate);
        toggleLeggings.onClick.AddListener(ToggleLeggings);
    }
    public bool tryToAddItem(int id)
    {
        for (int i = 0; i<5; i++) {
            if (hotbarSlots[i] == 0) {
                hotbarSlots[i] = id;
                return true;
            }
        }
        mainHUD.inventoryFullMessage();
        return false; //инвентарь полон
    }
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

    void ToggleBoots() {
        playerStats.equippedBoots = !playerStats.equippedBoots;
        playerStats.defense += PlayerStatsScript.defense_boots * (playerStats.equippedBoots ? 1 : -1);
        labelBoots.text = "Sturdy Boots " + (playerStats.equippedBoots ? "(On)" : "(Off)");
    }
    void ToggleHelmet() {
        playerStats.equippedHelmet = !playerStats.equippedHelmet;
        playerStats.defense += PlayerStatsScript.defense_helmet * (playerStats.equippedHelmet ? 1 : -1);
        labelHelmet.text = "War Helmet " + (playerStats.equippedHelmet ? "(On)" : "(Off)");
    }
    void ToggleChestplate() {
        playerStats.equippedChestplate = !playerStats.equippedChestplate;
        playerStats.defense += PlayerStatsScript.defense_chestplate * (playerStats.equippedChestplate ? 1 : -1);
        labelChestplate.text = "Chainmail Chestplate " + (playerStats.equippedChestplate ? "(On)" : "(Off)");
    }
    void ToggleLeggings() {
        playerStats.equippedLeggings = !playerStats.equippedLeggings;
        playerStats.defense += PlayerStatsScript.defense_leggings * (playerStats.equippedLeggings ? 1 : -1);
        labelLeggings.text = "Chainmail Leggings " + (playerStats.equippedLeggings ? "(On)" : "(Off)");
    }

    public void unlockChestplate() {
        playerStats.unlockedChestplate = true;
        toggleChestplate.interactable = true;
        ToggleChestplate();
    }

    public void unlockLeggings() {
        playerStats.unlockedLeggings = true;
        toggleLeggings.interactable = true;
        ToggleLeggings();
    }

    public void unlockHelmet() {
        playerStats.unlockedHelmet = true;
        toggleHelmet.interactable = true;
        ToggleHelmet();
    }

    public void unlockBoots() {
        playerStats.unlockedBoots = true;
        toggleBoots.interactable = true;
        ToggleBoots();
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