using UnityEngine;
using UnityEngine.UI;
using System;

public class Bar : MonoBehaviour
{
    public float value;
    public float maxValue;
    public Counter counter;
    RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (counter != null)
        {
            value = counter.value;
            maxValue = counter.maxValue;
        }
        rectTransform.sizeDelta = new Vector2(Math.Min((value / maxValue) * 100, 100f), 100f);
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
