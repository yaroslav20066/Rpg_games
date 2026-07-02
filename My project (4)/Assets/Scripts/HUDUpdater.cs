using System;
using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    public Canvas HUDCanvas;
    public Counter HPMeter;
    public Counter ArrowMeter;
    public GameObject XPmessageBoxObject;
    TextMeshProUGUI XPmessageBox;
    public PlayerStatsScript statSource;

    public bool XPmessageActive = false;

    public float XPmessageLength = 3f;

    public float XPmessageExistedFor = 0f;


    private void Start()
    {
        XPmessageBox = XPmessageBoxObject.GetComponent<TextMeshProUGUI>();
    }

    public void XPmessage(float xpGained, bool levelledUp)
    {
        XPmessageActive = true;
        XPmessageExistedFor = 0;

        XPmessageBoxObject.SetActive(true);

        XPmessageBox.text = "Gained " + xpGained.ToString() + " EXP!";
        if (levelledUp) {
            XPmessageBox.text += "\nYour level rose to " + statSource.LevelCounter.value.ToString() + ".";
        }
    }
    void Update()
    {
        HPMeter.value = (float)Math.Floor(statSource.health);
        HPMeter.maxValue = statSource.maxHealth;

        ArrowMeter.value = statSource.Arrows;
        ArrowMeter.maxValue = statSource.maxArrows;

        if (XPmessageActive)
        {
            XPmessageExistedFor += Time.deltaTime;
            if (XPmessageExistedFor >= XPmessageLength)
            {
                XPmessageBoxObject.SetActive(false);
                XPmessageActive = false;
            }
        }
    }
}
