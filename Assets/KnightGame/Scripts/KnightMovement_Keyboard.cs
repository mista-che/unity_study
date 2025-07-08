using UnityEngine;
using UnityEngine.InputSystem;

public class KnightMovement_Keyboard : KnightMovement
{
    Animator animator;
    Rigidbody2D knight_rigidbody;
    Vector3 input_direction;

    [SerializeField] float movement_speed = 5.0f;
    [SerializeField] float crouch_speed = 2.0f;
    [SerializeField] float jump_power = 30.0f;
    [SerializeField] float crouch_threshhold = -0.5f;
    //[SerializeField] float attack_damage = 3.0f;
    //[SerializeField] float attack_2_damage = 5.0f;

    bool is_grounded;
    bool is_crouching;
    bool is_combo;
    bool is_attacking;

    private void Start()
    {
        animator = GetComponent<Animator>();
        knight_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update() // gets inputs
    {
        GetKeyboardInput();
        Jump();
        CheckFalling();
        Attack();
    }

    private void FixedUpdate() // updates the physics
    {
        Movement();
    }

    void GetKeyboardInput()
    {
        // left/right movement
        float h = Input.GetAxisRaw("Horizontal"); // GetAxisRaw (-1 , 0 , 1)
        float v = Input.GetAxisRaw("Vertical");   // GetAxis (-1 ~ 1)
        input_direction = new Vector3(h, v, 0);

        // send input to Animator
        animator.SetFloat("KeyboardX", input_direction.x);
        animator.SetFloat("KeyboardY", input_direction.y);

        // flip
        if (input_direction.x != 0)
        {
            var scale_x = input_direction.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scale_x, 1, 1);
        }

        // set crouching
        if (input_direction.y < crouch_threshhold)
            is_crouching = true;
        else
            is_crouching = false;
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

    private void OnTriggerEnter2D(Collider2D collision) // Even though the Knight object itself has no triggers, it will catch child objects' trigger colliders.
    {
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log($"Knight hit the {collision.gameObject.name}!");
        }
    }

    private void Movement()
    {
        if (input_direction.x != 0)
        {
            if (is_crouching)
                knight_rigidbody.linearVelocityX = input_direction.x * crouch_speed;
            else
                knight_rigidbody.linearVelocityX = input_direction.x * movement_speed;
        }
    }

    private void Jump()
    {
        // jump input
        if (Input.GetKeyDown(KeyCode.Space) && is_grounded)
        {
            knight_rigidbody.AddForceY(jump_power, ForceMode2D.Impulse);
            animator.SetTrigger("is_jumping");
            // this is a one-time calculation, so it's okay to run in Update()
            // frequent calculations like WASD movement should be in FixedUpdate() for optimization purposes
            // actually, that's bullshit because player input should only be registered in fixed frames for game design purposes
            // ideally, i'd grab inputs in Update() and actually run Jump() in FixedUpdate()
        }
    }

    private void CheckFalling() // checks if knight is falling for fall animation
    {
        if (knight_rigidbody.linearVelocityY < -0.1) // magic number
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

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (!is_attacking && !is_combo)
            {
                animator.SetTrigger("is_attacking");
                is_attacking = true;
                Debug.Log("Attack(): is_attacking = false;");
            }
            else if (is_attacking && !is_combo)
            {
                is_combo = true;
                Debug.Log("Attack(): is_combo = true;");
            }
        }

    }
    private void CheckCombo()
    {
        if (is_combo)
        {
            animator.SetBool("is_combo", true);
            Debug.Log("Combo(): is_combo = true");
        }
        else
        {
            animator.SetBool("is_combo", false);
            is_attacking = false;
            Debug.Log("Combo(): is_combo = false");
        }
    }

    private void ResetCombo()
    {
        is_combo = false;
        is_attacking = false;
        Debug.Log("ResetCombo()");
    }
}


