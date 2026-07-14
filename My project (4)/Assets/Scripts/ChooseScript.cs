using UnityEngine;
using UnityEngine.UI;

public class ChooseScript : MonoBehaviour
{
    public Canvas canvas_this;

    public Canvas dialogue;
    public Image image;

    public Button button_silver;
    public Button button_fight;
    public Button button_ticket;
    public Button button_exit;
    public PlayerStatsScript playerStatsScript;

    void Start() {
        button_silver.onClick.AddListener(ChooseSilver);
        button_fight.onClick.AddListener(ChooseFight);
        button_ticket.onClick.AddListener(ChooseTickey);
        button_exit.onClick.AddListener(ChooseExit);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        Time.timeScale = 0f;
    }

    void Update() {
        button_silver.interactable = playerStatsScript.silver >= 750;
        button_ticket.interactable = playerStatsScript.ticket;
    }

    void ChooseSilver() {
        dialogue.gameObject.SetActive(true);
        Dialogue_bridge_silver script = image.GetComponent<Dialogue_bridge_silver>();
        script.enabled = true;

        canvas_this.gameObject.SetActive(false);
    }

    void ChooseFight() {
        dialogue.gameObject.SetActive(true);
        Dialogue_bridge_fight script = image.GetComponent<Dialogue_bridge_fight>();
        script.enabled = true;

        canvas_this.gameObject.SetActive(false);
    }

    void ChooseTickey() {
        dialogue.gameObject.SetActive(true);
        Dialogue_bridge_ticket script = image.GetComponent<Dialogue_bridge_ticket>();
        script.enabled = true;

        canvas_this.gameObject.SetActive(false);
    }

    void ChooseExit() {
        canvas_this.gameObject.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1f;
    }
}
