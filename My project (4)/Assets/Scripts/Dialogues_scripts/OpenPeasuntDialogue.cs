using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class OpenPeasuntDialogue : MonoBehaviour
{
    public Canvas dialoge_space;
    public Canvas quest_space;
    public Image image;
    public GameObject helper_of_priest;
    public GameObject trader;
    private bool check = true;
    private String queue;
    void Update()
    {
        if (trader == null && queue == null) {
            queue = "trader";
        }
        else if (helper_of_priest == null && queue == null) {
            queue = "helper";
        }

        if ((check && queue == "trader") || (check && queue == "helper")) {
            quest_space.gameObject.SetActive(true);
        }
        else {
            quest_space.gameObject.SetActive(false);
        }
    }
    public void OpenNewDialoge()
    {
        if (check && queue == "trader") {
            dialoge_space.gameObject.SetActive(true);
            Dialogue_peasunt_trader script = image.GetComponent<Dialogue_peasunt_trader>();
            script.enabled = true;
            check = false;
        }
        else if (check && queue == "helper") {
            dialoge_space.gameObject.SetActive(true);
            Dialogue_peasunt_helper script = image.GetComponent<Dialogue_peasunt_helper>();
            script.enabled = true;
            check = false;
        }
        
    }
}
