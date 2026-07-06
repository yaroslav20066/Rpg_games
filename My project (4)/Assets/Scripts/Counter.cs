using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public string defaultText;
    public float value;
    public float maxValue;
    TextMeshProUGUI countedTextbox;

    private void Start()
    {
        countedTextbox = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (countedTextbox != null)
        {
            countedTextbox.text = defaultText + value.ToString();
            if (maxValue > 0)
            {
                countedTextbox.text += "/" + maxValue.ToString();
            }
        }
    }

    public bool isFull()
    {
        return value >= maxValue;
    }
}
