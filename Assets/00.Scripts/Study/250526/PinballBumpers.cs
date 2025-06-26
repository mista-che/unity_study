using UnityEngine;

public class PinballBumpers : MonoBehaviour
{
    [SerializeField] Rigidbody2D left_bumper;
    [SerializeField] Rigidbody2D right_bumper;
    [SerializeField] Rigidbody2D play_ball;
    bool left_button_pressed;
    bool right_button_pressed;

    private void Start()
    {
        left_button_pressed = false;
        right_button_pressed = false;
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
            left_button_pressed = true;
        else
            left_button_pressed = false;
        if (Input.GetKey(KeyCode.D))
            right_button_pressed = true;
        else
            right_button_pressed = false;
        if (play_ball.transform.position.y < -5f)
            play_ball.transform.position = Vector3.right;
    }

    private void FixedUpdate()
    {
        if (left_button_pressed)
            left_bumper.AddTorque(30f);
        else
            left_bumper.AddTorque(-25f);
        if (right_button_pressed)
            right_bumper.AddTorque(-30f);
        else
            right_bumper.AddTorque(25f);
    }
}
