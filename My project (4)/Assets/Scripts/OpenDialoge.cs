using UnityEngine.UI;
using UnityEngine;

public class OpenDialoge : MonoBehaviour
{
    public Canvas dialoge_space;
    public Image image;
    private bool check = true;
    public void OpenNewDialoge()
    {
        if (check)
        {
            Debug.Log("Helo");
            dialoge_space.gameObject.SetActive(true);
            Dialogue_bridge_1 script = image.GetComponent<Dialogue_bridge_1>();
            script.enabled = true;
            check = false;
        }
        
    }
}
