using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenHelper_Dialogue : MonoBehaviour
{
    public Canvas dialoge_space;
    public Canvas quest_space;
    public Image image;
    public TextMeshProUGUI goal;
    MainGoalCounter counter;
    private bool check = true;
    void Start() {
        counter = goal.GetComponent<MainGoalCounter>();
    }
    void Update()
    {
        if (check && counter.step_priest > 1) {
            quest_space.gameObject.SetActive(true);
        }
        else {
            quest_space.gameObject.SetActive(false);
        }
    }
    public void OpenNewDialoge()
    {
        if (check && counter.step_priest > 1)
        {
            dialoge_space.gameObject.SetActive(true);
            Dialogue_helper_priest script = image.GetComponent<Dialogue_helper_priest>();
            script.enabled = true;
            check = false;
        }
        
    }
}
