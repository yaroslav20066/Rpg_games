using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenChurchDialoge : MonoBehaviour
{
    public Canvas dialoge_space;
    public Image image;
    public TextMeshProUGUI goal;
    MainGoalCounter counter;
    private bool check_1 = true;
    private bool check_2 = true;
    private bool check_3 = true;
    void Start()
    {
        counter = goal.GetComponent<MainGoalCounter>();
    }
    public void OpenNewDialoge()
    {
        if (check_1 && counter.step > 1)
        {
            dialoge_space.gameObject.SetActive(true);
            Dialogue_priest_1 script = image.GetComponent<Dialogue_priest_1>();
            script.enabled = true;
            check_1 = false;
        }
        else if (check_2 && counter.step_priest > 2)
        {
            dialoge_space.gameObject.SetActive(true);
            Dialog_priest_2 script = image.GetComponent<Dialog_priest_2>();
            script.enabled = true;
            check_2 = false;
        }
        else if (check_3 && counter.step_priest > 4)
        {
            dialoge_space.gameObject.SetActive(true);
            Dialog_priest_3 script = image.GetComponent<Dialog_priest_3>();
            script.enabled = true;
            check_3 = false;
        }
    }
}
