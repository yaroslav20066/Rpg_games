using System.Diagnostics.CodeAnalysis;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class IteractionScript : MonoBehaviour
{
    private Camera cam;
    public TextMeshProUGUI interac_text;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    public void interact(bool interact)
    {
        Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
        Ray ray = cam.ScreenPointToRay(point);
        RaycastHit hit;

        interac_text.gameObject.SetActive(false);

        if (Physics.Raycast(ray, out hit, 3.0f)) {
            GameObject hitObject = hit.transform.gameObject;

            if (hitObject.CompareTag("Interactive")) {
                interac_text.gameObject.SetActive(true);
            }

            if (interact) {
            
                hitObject.SendMessage("OpenNewDialoge", SendMessageOptions.DontRequireReceiver);
                hitObject.SendMessage("pickUp", SendMessageOptions.DontRequireReceiver);
            }     
        }   
    }
}
