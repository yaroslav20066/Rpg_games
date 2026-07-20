using UnityEngine;
using UnityEngine.Events;

public class TriggerByCollision : MonoBehaviour
{
    public UnityEvent[] events;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            for (int i = 0; i < events.Length; i++)
            {
                events[i].Invoke();
            }
            Destroy(gameObject);
        }
    }
}
