using UnityEngine;

public class CollisionEvent2D : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D _collision)
    {
        Debug.Log($"{name} & {_collision.gameObject.name}: OnCollisionEnter2D()");
    }

    private void OnCollisionExit2D(Collision2D _collision)
    {
        Debug.Log($"{name} & {_collision.gameObject.name}: OnCollisionExit2D()");
    }

    private void OnCollisionStay2D(Collision2D _collision)
    {
        Debug.Log($"{name} & {_collision.gameObject.name}: OnCollisionStay2D()"); // , Count: { i++})
        // similar to Update(), continually fires. fired about 50 times per second.
        // only keeps firing if you hold the direction key. else, it stops calculating physics after a while (for optimization reasons).
        // note: you don't need to use "i" to increment things here. Unity console's collapse feature collates all identical messages for a pseudo-count.
    }
}
