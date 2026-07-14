using UnityEngine.UI;
using UnityEngine;

public class OpenBridgeDialoge : MonoBehaviour
{
    public Canvas dialoge_space;
    public Canvas choose_table;
    public Image image;
    public Image image_choose;
    public MainGoalCounter counter;
    private bool check = true;
    public void OpenNewDialoge()
    {
        if (check) {
            dialoge_space.gameObject.SetActive(true);
            Dialogue_bridge_1 script = image.GetComponent<Dialogue_bridge_1>();
            script.enabled = true;
            check = false;
        }

        if (counter.step > 1) {
            choose_table.gameObject.SetActive(true);
            ChooseScript script = image_choose.GetComponent<ChooseScript>();
            script.enabled = true;

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            Time.timeScale = 0f;
        }
        
    }
}
