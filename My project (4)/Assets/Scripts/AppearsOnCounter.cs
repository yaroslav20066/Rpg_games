using UnityEngine;

public class AppearsOnCounter : MonoBehaviour
{
    public Counter counter;
    public GameObject toAppear;
    public bool inverted;
    bool appear;


    void Update()
    {
        toAppear.SetActive(appear);
        appear = counter.isFull() ^ inverted;
    }
}
