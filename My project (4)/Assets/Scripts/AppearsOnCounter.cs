using UnityEngine;

public class AppearsOnCounter : MonoBehaviour
{
    public Counter counter;
    public GameObject toAppear;
    public bool inverted;


    void Update()
    {
        toAppear.SetActive(counter.isFull() ^ inverted);
    }
}
