using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;

public class IteractionScript : MonoBehaviour
{
    private Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    public void interact(bool interact)
    {
        if (interact)
        {
            Vector3 point = new Vector3(cam.pixelWidth / 2, cam.pixelHeight / 2, 0);
            Ray ray = cam.ScreenPointToRay(point);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 3.0f)) {
                GameObject hitObject = hit.transform.gameObject;
                hitObject.SendMessage("OpenNewDialoge", SendMessageOptions.DontRequireReceiver);
            }     
        }
        
    }
    
}
