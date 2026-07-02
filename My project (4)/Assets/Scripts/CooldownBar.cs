using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CooldownBar : MonoBehaviour
{
    public Bar FillerBar;
    public GameObject BarFrame;
    public float timeElapsed;
    public float maxCooldown;
    private bool finished = true;
    void Start()
    {
        finished = true;
        FillerBar.maxValue = 0;
        FillerBar.value = 0;

        BarFrame.SetActive(false);
        FillerBar.SetActive(false);
    }

    void Update()
    {
        if (finished) return;

        timeElapsed += Time.deltaTime;
        if (timeElapsed >= maxCooldown) {
            BarFrame.SetActive(false);
            FillerBar.SetActive(false);
            finished = true;
            
            FillerBar.maxValue = 0;
            FillerBar.value = 0;
            SetBarColor(Color.white);
        }
        FillerBar.value = timeElapsed;


    }
    public void beginCountdown(float maxCooldown_)
    {
        maxCooldown = maxCooldown_;
        timeElapsed = 0;
        finished = false;

        BarFrame.SetActive(true);
        FillerBar.SetActive(true);

        FillerBar.maxValue = maxCooldown;
        FillerBar.value = 0;
    }

    public void SetBarColor(Color color)
    {
        FillerBar.SetColor(color);
    }

    public bool cooldownFinished()
        { return finished; }    
    }
