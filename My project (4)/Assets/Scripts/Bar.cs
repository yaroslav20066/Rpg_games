using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public float value;
    public float maxValue;
    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.sizeDelta = new Vector2((value / maxValue) * 100, 100f);
    }

    public bool isFull()
    {
        return value >= maxValue;
    }

    public void setFull()
    {
        value = maxValue;
    }

    public void SetColor(Color color)
    {
        if (GetComponent<Image>() != null)
        {
            GetComponent<Image>().color = color;
        }
    }

    public void SetActive(bool active)
    {
        SetActive(active);
    }
}
