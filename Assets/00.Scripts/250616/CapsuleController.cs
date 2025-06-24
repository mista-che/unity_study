using Unity.VisualScripting;
using UnityEngine;

public class CapsuleController : MonoBehaviour
{
    [SerializeField] private float move_speed = 3.0f;
    [SerializeField] private IPickupable current_item;
    [SerializeField] private Transform held_position;

    private void Update()
    {
        Move();
        Interact();
    }

    private void Move()
    {
        float hrzn = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(hrzn, 0, vert).normalized;

        transform.position += dir * move_speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (current_item == null)
        {
            current_item = other.GetComponent<IPickupable>();
            current_item.Pickup(held_position);
        }
    }

    private void Interact()
    {
        if (current_item == null)
            return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            current_item.Use();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            current_item.Drop();
            current_item = null;
        }
    }
}
