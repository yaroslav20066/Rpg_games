using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_trader_2 : MonoBehaviour
{
    [System.Serializable]
    public class Choice
    {
        public bool bad = false;
        public string text;      
        public int nextNode;     
    }

    [System.Serializable]
    public class DialogueNode
    {
        public string speaker;
        [TextArea]
        public string dialogue;
        public Choice[] choices;
    }
    public Canvas canvas;
    public TextMeshProUGUI person;
    public TextMeshProUGUI dialogue;

    public TextMeshProUGUI textButton1;
    public TextMeshProUGUI textButton2;
    public TextMeshProUGUI Main_goal;
    MainGoalCounter counter;
    public GameObject player;
    PlayerStatsScript playerStatsScript;

    public TradeWindowScript tradeWindowScript;

    public GameObject trader;
    public Canvas trading;

    public Button button1;
    public Button button2;
    private int currentNode;

    public DialogueNode[] nodes;

    void Start() {
        playerStatsScript = player.GetComponent<PlayerStatsScript>();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        Time.timeScale = 0f;

        button1.onClick.AddListener(() => Choose(0));
        button2.onClick.AddListener(() => Choose(1));

        counter = Main_goal.GetComponent<MainGoalCounter>();

        ShowNode(0);
    }

    void ShowNode(int index) {
        currentNode = index;

        DialogueNode node = nodes[index];

        person.text = node.speaker;

        dialogue.text = node.dialogue;

        if (node.choices.Length > 0) {
            button1.gameObject.SetActive(true);
            textButton1.text = node.choices[0].text;
        }
        else {
            button1.gameObject.SetActive(false);
        }

        if (node.choices.Length > 1) {
            button2.gameObject.SetActive(true);
            textButton2.text = node.choices[1].text;
        }
        else {
            button2.gameObject.SetActive(false);
        }
    }

    void Choose(int choiceIndex)
    {
        DialogueNode node = nodes[currentNode];

        if (choiceIndex >= node.choices.Length)
            return;

        int next = node.choices[choiceIndex].nextNode;

        if (node.choices[choiceIndex].bad) {
            tradeWindowScript.increaseFine();
        }

        if (next >= 0) {
            ShowNode(next);
        }
        else {
            currentNode = 0;
            EndDialogue_trader();
        }
    }

    void EndDialogue_trader()
    {
        enabled = false;
        canvas.gameObject.SetActive(false);

        playerStatsScript.TakeExperience(100);
        counter.NewTraderStep();

        openTrade();

        Destroy(this);
    }

    void openTrade()
    {
        trading.gameObject.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;

        Time.timeScale = 0f;
    }
}
