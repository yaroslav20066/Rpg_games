using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OpenHelper_Dialogue : MonoBehaviour
{
    public Canvas dialoge_space;
    public Image image;
    public TextMeshProUGUI goal;
    MainGoalCounter counter;
    private bool check = true;
    void Start()
    {
        counter = goal.GetComponent<MainGoalCounter>();
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
