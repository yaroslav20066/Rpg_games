using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    public int silver;
    public int podorozhnik;
    public int bandage;
    public int sugar;
    public int remedy;
    public PlayerStatsScript playerStatsScript;
    public ItemInventory itemInventory;
    public UnityEvent[] events;

    public void pickUp()
    {
        playerStatsScript.silver += silver;
        for (int i = 0; i < podorozhnik; i++) {
            itemInventory.tryToAddItem(1);
        }
        for (int i = 0; i < bandage; i++)
        {
            itemInventory.tryToAddItem(2);
        }
        for (int i = 0; i < sugar; i++)
        {
            itemInventory.tryToAddItem(3);
        }
        for (int i = 0; i < remedy; i++)
        {
            itemInventory.tryToAddItem(4);
        }
        for (int i = 0; i < events.Length; i++)
        {
            events[i].Invoke();
        }
        Destroy(gameObject);
    }
}
