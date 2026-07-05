using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TakeCrossScript : MonoBehaviour
{
    public TextMeshProUGUI goal;
    MainGoalCounter counter;
    private bool check = true;

    void Start()
    {
        counter = goal.GetComponent<MainGoalCounter>();
    }
    public void OpenNewDialoge()
    {
        if (check && counter.step_priest > 3)
        {
            counter.NewPriestStep();
            Debug.Log("Вы подобрали Золотой крест");
            check = false;
            Destroy(this.gameObject);
        }
    }
}
