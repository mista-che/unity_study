using UnityEngine;
using UnityEngine.UI;

public class KnightMovement_Town : KnightMovement
{
    Animator animator;
    Rigidbody2D knight_rigidbody;
    Vector3 input_direction;

    [SerializeField] float movement_speed = 6.0f;
    [SerializeField] float knight_size = 0.5f;

    [SerializeField] Button interaction_button;

    bool keyboard_active;
    bool joystick_active;


    private void Start()
    {
        animator = GetComponent<Animator>();
        knight_rigidbody = GetComponent<Rigidbody2D>();

        // assign button to interaction?
    }

    private void Update()
    {
        SetKeyboardInput();
    }

    private void FixedUpdate()
    {
        Movement();
        Flip();
    }

    public override void SetJoystickInput(float x, float y)
    {
        if (!keyboard_active)
        {
            input_direction = new Vector3(x, y, 0).normalized;
            if (x != 0 || y != 0)
                joystick_active = true;
            else
                joystick_active = false;
        }
    }

    private void SetKeyboardInput()
    {
        if (!joystick_active)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            input_direction = new Vector3(h, v, 0);
            if (h != 0 || v != 0)
                keyboard_active = true;
            else
                keyboard_active = false;
        }
    }

    private void ResetInputs()
    {
        if (input_direction.x == 0 && input_direction.y == 0)
        {
            keyboard_active = false;
            joystick_active = false;
        }
    }

    private void Flip()
    {
        // flips knight direction based on current input direction
        if (input_direction.x != 0)
        {
            var scale_x = input_direction.x > 0 ? knight_size : knight_size * -1;
            transform.localScale = new Vector3(scale_x, knight_size, knight_size);
        }
    }

    private void Movement()
    {

        knight_rigidbody.linearVelocityX = input_direction.x * movement_speed;
        knight_rigidbody.linearVelocityY = input_direction.y * movement_speed;

        if (input_direction == Vector3.zero)
            animator.SetBool("is_moving", false);
        else
            animator.SetBool("is_moving", true);
    }
}
