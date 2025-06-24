using UnityEngine;

public class KnightMovement_Keyboard : MonoBehaviour
{
    Animator animator;
    Rigidbody2D knight_rigidbody;
    Vector3 input_direction;
    [SerializeField] float movement_speed = 5.0f;
    [SerializeField] float jump_power = 25.0f;
    bool is_grounded;
    // bool is_falling;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knight_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() // gets inputs
    {
        InputKeyboard();
        Jump();
        CheckFalling();
    }

    private void FixedUpdate() // updates the physics
    {
        Movement();
    }

    void InputKeyboard()
    {
        // left/right movement
        float h = Input.GetAxis("Horizontal"); // GetAxisRaw (-1 , 0 , 1)
        float v = Input.GetAxis("Vertical");   // GetAxis (-1 ~ 1
        input_direction = new Vector3(h, v, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("is_grounded", true);
            is_grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            animator.SetBool("is_grounded", false);
            is_grounded = false;

        }
    }

    void Movement()
    {
        if (input_direction.x != 0)
        {
            knight_rigidbody.linearVelocityX = input_direction.x * movement_speed;
            animator.SetBool("is_running", true);

            // flip
            var scale_x = input_direction.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scale_x, 1, 1);
        }
        else if (input_direction.x == 0)
            animator.SetBool("is_running", false);
    }

    void Jump()
    {
        // jump input
        if (Input.GetKeyDown(KeyCode.Space) && is_grounded)
        {
            animator.SetTrigger("is_jumping");
            knight_rigidbody.AddForceY(jump_power, ForceMode2D.Impulse);
            // this is a one-time calculation, so it's okay to run in Update()
            // frequent calculations like WASD movement should be in FixedUpdate() for optimization purposes
            // actually, that's bullshit because player input should only be registered in fixed frames for game design purposes
            
        }
    }

    void CheckFalling() // checks if knight is falling for fall animation
    {
        if (knight_rigidbody.linearVelocityY < 0)
        {
            animator.SetBool("is_falling", true);
            // is_falling = true;
        }
        else if (knight_rigidbody.linearVelocityY >= 0)
        {
            animator.SetBool("is_falling", false);
            // is_falling = false;
        }
    }
}
