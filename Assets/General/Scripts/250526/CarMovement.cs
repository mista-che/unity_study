using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float movement_speed = 15f;
    public Rigidbody2D car_rigidbody;
    private float h;

    void Update()
    {
        // transform.position isn't actually physics-based movement, it is a simple position shift. it may lead to weird behavior when used in conjunction with other physics-based behaviors.
        // transform.position += h * movement_speed * Time.deltaTime * Vector3.right;

        h = Input.GetAxis("Horizontal"); // it is better to get inputs in Update(), always, since FixedUpdate only checks every so often vs Update checking more often.
    }

    void FixedUpdate()
    { 
        // a more physics-based way of moving 
        car_rigidbody.linearVelocityX = h * movement_speed; // remember to remove Time.deltaTime when using fixedUpdate. no need to adjust for the performance variations of Update() if using FixedUpdate()

    }
}
