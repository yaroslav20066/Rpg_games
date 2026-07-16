using System.Data.Common;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenTraderDialogue : MonoBehaviour
{
    public Canvas dialoge_space;
    public Canvas quest_space;
    public Image image;
    public TextMeshProUGUI goal;
    MainGoalCounter counter;
    public Canvas trading;
    private bool check_1 = true;
    private bool check_2 = true;
    void Start() {
        counter = goal.GetComponent<MainGoalCounter>();
    }
    void Update()
    {
        if ((check_1 && counter.step > 1) || (check_2 && counter.step_trader > 1) 
         || (counter.step_trader > 2)) {
            quest_space.gameObject.SetActive(true);
        }
        else {
            quest_space.gameObject.SetActive(false);
        }
    }
    public void OpenNewDialoge()
    {
        if (check_1 && counter.step > 1) {
            dialoge_space.gameObject.SetActive(true);
            Dialogue_trader_1 script = image.GetComponent<Dialogue_trader_1>();
            script.enabled = true;
            check_1 = false;
        }
        else if (check_2 && counter.step_trader > 1) {
            dialoge_space.gameObject.SetActive(true);
            Dialogue_trader_2 script = image.GetComponent<Dialogue_trader_2>();
            script.enabled = true;
            check_2 = false;
        }
        else if (counter.step_trader > 2) {
            trading.gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
        }
    }
}
