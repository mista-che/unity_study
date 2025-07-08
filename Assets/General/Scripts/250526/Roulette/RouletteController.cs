using UnityEngine;

public class RouletteController : MonoBehaviour
{
    public float rotation_speed = 5f;
    public bool is_spinning = true;
    public  bool is_slowing = false;

    private void Start()
    {
        // resets speed to 5
        rotation_speed = 0f;
        is_spinning = false;
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward * rotation_speed);
        // equivalent to (transform.Rotate(0f, 0f, rotation_speed), rotates object forward on the Z-axis

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rotation_speed = 5f;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            is_slowing = true;
        }

        if (is_slowing == true)
        {
            rotation_speed *= 0.98f;

            if (rotation_speed < 0.01f)
            {
                rotation_speed = 0f;
                is_slowing = false;               
            }
        }
    }
}
