using UnityEngine;

public class BoxLootScript : MonoBehaviour
{
    public PlayerStatsScript playerStatsScript;
    public ItemInventory itemInventory;
    private bool check = true;
    [SerializeField] private int silver;
    [SerializeField] private int arrow;

    public int podorozhnik;
    public int bandage;
    public int sugar;
    public int remedy;

    void Start() {
        silver = (int)Random.Range(25f, 75f);
        arrow = (int) Random.Range(0f, 2f);
    }

    public void OpenNewDialoge() {
        if (check) {
            playerStatsScript.getSilver(silver);
            silver = 0;

            playerStatsScript.getArrow(arrow);
            arrow = 0;

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
            if (silver + podorozhnik + bandage + sugar + remedy + arrow <= 0) {
                check = false;
            }
        }
    }
}
