using UnityEngine;

public class GunController : MonoBehaviour, IPickupable
{
    [SerializeField] GameObject bullet;
    [SerializeField] Transform shooting_position;
    [SerializeField] float bullet_velocity = 1000f;

    public void Pickup(Transform held_position)
    {
        transform.SetParent(held_position);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }

    public void Use()
    {
        GameObject bullet_instance = Instantiate(bullet, shooting_position.position, Quaternion.identity);
        Rigidbody bullet_rigidbody = bullet.GetComponent<Rigidbody>();
        bullet_rigidbody.AddForce(shooting_position.forward * bullet_velocity, ForceMode.Impulse);
    }

    public void Drop()
    {
        transform.SetParent(null);
        transform.position = Vector3.zero;
    }
}
