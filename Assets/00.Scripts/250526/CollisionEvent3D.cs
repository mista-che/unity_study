using UnityEngine;

public class CollisionEvent3D : MonoBehaviour
{
    void OnCollisionEnter(Collision _collision)
    {
        Debug.Log($"{name}: OnCollisionEnter()"); // plays if both objects do not have the "Is Trigger" flag
    }

    void OnTriggerEnter(Collider _collider)
    {
        Debug.Log($"{name}: OnTriggerEnter()"); // plays if at least one involved object has the "Is Trigger" flag
    }


}
