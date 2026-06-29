using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    public string defaultText;
    public float value;
    public float maxValue;
    public Bar bar;
    TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (bar != null)
        {
            value = bar.value;
            maxValue = bar.maxValue;
        }
        text.text = defaultText + value.ToString();
        if (maxValue > 0)
        {
            text.text += "/" + maxValue.ToString();
        }
    }
}
