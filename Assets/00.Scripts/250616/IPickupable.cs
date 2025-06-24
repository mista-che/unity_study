using UnityEngine;

public interface IPickupable
{
    void Pickup(Transform held_position);
    void Use();
    void Drop();

}
