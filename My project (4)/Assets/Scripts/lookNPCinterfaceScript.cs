using UnityEngine;

public class lookNPCinterfaceScript : MonoBehaviour
{
    Transform target;

    void Start() {
        target = PlayerManager.instance.player.transform;       
    }
    
    void Update() {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 100);
    }
}
