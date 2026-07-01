using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Dialoge_bridge_1 : MonoBehaviour
{
    public TextMeshProUGUI person;
    public TextMeshProUGUI dialogie;
    public TextMeshProUGUI text_button_1;
    public TextMeshProUGUI text_button_2;
    public Button button_1;
    public Button button_2;

    private int left = 0;
    private int right = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        person.text = "Стражник:";
        person.color = Color.blue;

        dialogie.text = "Стой, кто идет?";

        text_button_1.text = "Обычный путник, идущий к городу";
        text_button_2.text = "Солдат Кровавой войны в отставки, герой в битве при Кортева";
        button_1.onClick.AddListener(leftChoice);
        button_2.onClick.AddListener(rightChoice);
    }

    public void leftChoice()
    {
        if (left == 0 && right == 0)
        {
            dialogie.text = "";
        }
    }

    public void rightChoice()
    {
        if (left == 0 && right == 0)
        {
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
