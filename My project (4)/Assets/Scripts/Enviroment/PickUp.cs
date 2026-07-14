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
    public bool disappearsOnEmpty = true;

    public void pickUp()
    {
        playerStatsScript.silver += silver;
        silver = 0;
        for (int i = 0; i < remedy; i++)
        {
            if (itemInventory.tryToAddItem(4))
            {
                remedy--;
            }
        }
        for (int i = 0; i < bandage; i++)
        {
            if (itemInventory.tryToAddItem(2))
            {
                bandage--;
            }
        }
        for (int i = 0; i < sugar; i++)
        {
            if (itemInventory.tryToAddItem(3))
            {
                sugar--;
            }
        }
        for (int i = 0; i < podorozhnik; i++) {
            if (itemInventory.tryToAddItem(1))
            {
                podorozhnik--;
            }
        }
        for (int i = 0; i < events.Length; i++)
        {
            events[i].Invoke();
        }
        if (disappearsOnEmpty && silver + podorozhnik + bandage + sugar + remedy <= 0)
        {
            Destroy(gameObject);
        }
    }
}
