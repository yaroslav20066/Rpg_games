using UnityEngine;
using UnityEngine.UI;

public class OpenChurchDialoge : MonoBehaviour
{
    public Canvas dialoge_space;
    public Image image;
    private bool check = true;
    public void OpenNewDialoge()
    {
        if (check)
        {
            dialoge_space.gameObject.SetActive(true);
            Dialogue_priest_1 script = image.GetComponent<Dialogue_priest_1>();
            script.enabled = true;
            check = false;
        }
        
    }
}
