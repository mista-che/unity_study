using UnityEngine;

public class DestroyEvent : MonoBehaviour
{
    private void OnDestroy()
    {
        Debug.Log($"{this.gameObject.name}: Noooo!)");
    }
}
