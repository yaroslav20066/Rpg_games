using System;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HUD : MonoBehaviour
{
    public Canvas HUDCanvas;
    public Counter HPMeter;
    public Counter ArrowMeter;
    public GameObject XPmessageBoxObject;
    public RawImage[] slotObjectsByNumber = {null, null, null, null, null}; //всё выбирается в инспекторе
    public Texture[] texturesByID = {null, null, null, null, null};
    public ItemInventory itemInventory;
    TextMeshProUGUI XPmessageBox;
    public PlayerStatsScript statSource;
    public int hotbarSelectedSlot = 0;
    public GameObject hotbarSelectedSlotOverlay;

    public bool XPmessageActive = false;
    public bool inventoryOpen = false;

    public float XPmessageLength = 3f;

    public float XPmessageExistedFor = 0f;
    UnityEngine.Vector3 originalHotbarOverlayPos, newHotbarOverlayPos;
    RectTransform hotbarOverlayRectTransform;


    private void Start()
    {
        XPmessageBox = XPmessageBoxObject.GetComponent<TextMeshProUGUI>();
        hotbarOverlayRectTransform = hotbarSelectedSlotOverlay.GetComponent<RectTransform>();
        originalHotbarOverlayPos = hotbarOverlayRectTransform.position;
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

        newHotbarOverlayPos = originalHotbarOverlayPos;
        newHotbarOverlayPos.x += hotbarSelectedSlot*27 + 14*hotbarSelectedSlot;
        if (inventoryOpen) newHotbarOverlayPos.y += 64;
        hotbarOverlayRectTransform.position = newHotbarOverlayPos;

        //отрисовка предметов в хотбаре
        for (int i = 0; i<5; i++) {
            //int abc = itemInventory.hotbarSlots[0];
            slotObjectsByNumber[i].texture = texturesByID[itemInventory.hotbarSlots[i]];
        }
        

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
