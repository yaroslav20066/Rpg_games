using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TradeWindowScript : MonoBehaviour
{
    public Button plantain;
    public Button bandage;
    public Button sugar;
    public Button potion;
    public Button armor;
    public Button arrow;
    public Button close;

    public PlayerStatsScript playerStatsScript;
    public Canvas trading;

    public TextMeshProUGUI Text_silver;

    public TextMeshProUGUI Text_plantain;
    public TextMeshProUGUI Text_bandage;
    public TextMeshProUGUI Text_sugar;
    public TextMeshProUGUI Text_potion;
    public TextMeshProUGUI Text_armor;
    public TextMeshProUGUI Text_arrow;

    public int fine = 1;

    void Start() {
        plantain.onClick.AddListener(BuyPlantain);
        bandage.onClick.AddListener(BuyBandage);
        sugar.onClick.AddListener(BuySugar);
        potion.onClick.AddListener(BuyPotion);
        armor.onClick.AddListener(BuyArmor);
        arrow.onClick.AddListener(BuyArrow);
        close.onClick.AddListener(Close);

        Text_silver.text = $"Silver: {playerStatsScript.silver}";
        Text_plantain.text = $"{10 * fine}";
        Text_bandage.text = $"{30 * fine}";
        Text_sugar.text = $"{40 * fine}";
        Text_potion.text = $"{250 * fine}";
        Text_armor.text = $"{100 * fine}";
        Text_arrow.text = $"{20 * fine}";
    }

    void Update() {
        Text_silver.text = $"Silver: {playerStatsScript.silver}";
    }

    void BuyPlantain() 
    {
        if (playerStatsScript.silver >= (10 * fine)) {
            playerStatsScript.getSilver(-1 * 10 * fine);

            plantain.interactable = false;
        }
    }

    void BuyBandage() 
    {
        if (playerStatsScript.silver >= (30 * fine)) {
            playerStatsScript.getSilver(-1 * 30 * fine);

            bandage.interactable = false;
        }
    }

    void BuySugar() 
    {
        if (playerStatsScript.silver >= (40 * fine)) {
            playerStatsScript.getSilver(-1 * 40 * fine);

            sugar.interactable = false;
        }
    }

    void BuyPotion() 
    {
        if (playerStatsScript.silver >= (250 * fine)) {
            playerStatsScript.getSilver(-1 * 250 * fine);

            potion.interactable = false;
        }
    }

    void BuyArmor() 
    {
        if (playerStatsScript.silver >= (100 * fine)) {
            playerStatsScript.getSilver(-1 * 100 * fine);
            playerStatsScript.getArmor(1);
            armor.interactable = false;
        }
    }

    void BuyArrow() 
    {
        if (playerStatsScript.silver >= (20 * fine) && playerStatsScript.Arrows < playerStatsScript.maxArrows) {
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
