using UnityEngine;

public class InputSystem : MonoBehaviour
{
    [SerializeField] private float newMoveSpeed = 5f;
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 currentDirection = new(h, 0, v);

        transform.position += newMoveSpeed * Time.deltaTime * currentDirection;
    }
}
