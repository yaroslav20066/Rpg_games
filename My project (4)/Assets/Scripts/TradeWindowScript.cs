using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TradeWindowScript : MonoBehaviour
{
    public Button bandage;
    public Button sugar;
    public Button potion;
    public Button leggings;
    public Button chestplate;
    public Button arrow;
    public Button close;

    public PlayerStatsScript playerStatsScript;
    public ItemInventory itemInventory;
    public Canvas trading;
    
    public HUD mainHUD;

    public TextMeshProUGUI Text_silver;
    public TextMeshProUGUI Text_bandage;
    public TextMeshProUGUI Text_sugar;
    public TextMeshProUGUI Text_potion;
    public TextMeshProUGUI Text_chestplate;
    public TextMeshProUGUI Text_leggings;
    public TextMeshProUGUI Text_arrow;

    public int fine = 1;

    void Start() {
        bandage.onClick.AddListener(BuyBandage);
        sugar.onClick.AddListener(BuySugar);
        potion.onClick.AddListener(BuyPotion);
        chestplate.onClick.AddListener(BuyChestplate);
        leggings.onClick.AddListener(BuyLeggings);
        arrow.onClick.AddListener(BuyArrow);
        close.onClick.AddListener(Close);

        Text_silver.text = $"Silver: {playerStatsScript.silver}";
        Text_leggings.text = $"{80 * fine}";
        Text_bandage.text = $"{30 * fine}";
        Text_sugar.text = $"{40 * fine}";
        Text_potion.text = $"{250 * fine}";
        Text_chestplate.text = $"{100 * fine}";
        Text_arrow.text = $"{20 * fine}";
    }

    void Update() {
        Text_silver.text = $"Silver: {playerStatsScript.silver}";
    }

    void BuyBandage() 
    {
        if (playerStatsScript.silver >= (30 * fine)) {
            if (!itemInventory.tryToAddItem(ItemInventory.item_bandage)) { return; }

            playerStatsScript.getSilver(-1 * 30 * fine);
            bandage.interactable = false;
        }
    }

    void BuySugar() 
    {
        if (playerStatsScript.silver >= (40 * fine)) {
            if (!itemInventory.tryToAddItem(ItemInventory.item_sugar)) { return; }

            playerStatsScript.getSilver(-1 * 40 * fine);
            sugar.interactable = false;
        }
    }

    void BuyPotion() 
    {
        if (playerStatsScript.silver >= (250 * fine)) {
            if (!itemInventory.tryToAddItem(ItemInventory.item_remedy)) { return; }

            playerStatsScript.getSilver(-1 * 250 * fine);
            potion.interactable = false;
        }
    }

    void BuyLeggings() 
    {
        if (playerStatsScript.silver >= (80 * fine)) {
            playerStatsScript.getSilver(-1 * 80 * fine);

            itemInventory.unlockLeggings();
            leggings.interactable = false;
        }
    }

    void BuyChestplate() 
    {
        if (playerStatsScript.silver >= (100 * fine)) {
            playerStatsScript.getSilver(-1 * 100 * fine);

            itemInventory.unlockChestplate();
            chestplate.interactable = false;
        }
    }

    void BuyArrow() 
    {
        if (playerStatsScript.silver >= (20 * fine)) {
            if (playerStatsScript.Arrows >= playerStatsScript.maxArrows) {
                mainHUD.inventoryFullMessage();
                return;
            }

            playerStatsScript.getSilver(-1 * 20 * fine);
            playerStatsScript.getArrow(1);
        }
    }

    void Close()
    {
        trading.gameObject.SetActive(false);
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1f;
    }

    public void increaseFine() {
        fine += 1;
    }
}
