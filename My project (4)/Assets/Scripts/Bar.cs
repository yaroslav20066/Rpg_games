using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    public float value;
    public float maxValue;
    public GameObject BarObject;
    RectTransform rectTransform;

    void Start()
    {
        rectTransform = BarObject.GetComponent<RectTransform>();
    }

    void Update()
    {
        rectTransform.sizeDelta = new Vector2((value / maxValue) * 100, 100f);
    }

    public bool full()
    {
        return value >= maxValue;
    }

    public void setFull()
    {
        value = maxValue;
    }

    public void SetColor(Color color)
    {
        if (BarObject.GetComponent<Image>() != null)
        {
            BarObject.GetComponent<Image>().color = color;
        }
    }

    public void SetActive(bool active)
    {
        BarObject.SetActive(active);
    }
}
