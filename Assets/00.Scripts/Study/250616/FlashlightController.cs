using UnityEngine;

public class FlashlightController : MonoBehaviour, IPickupable
{
    [SerializeField] GameObject light_object;

    public void Pickup(Transform held_position)
    {
        transform.SetParent(held_position);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void Use()
    {
        light_object.SetActive(!light_object.activeSelf);
    }

    public void Drop()
    {
        transform.SetParent(null);
        transform.position = Vector3.zero;
    }
}
