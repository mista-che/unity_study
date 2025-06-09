using UnityEngine;
using Cat; // necessary to use SoundManager

public class CatController : MonoBehaviour
{
    private Rigidbody2D cat_rigidbody;
    private Animator cat_animator;
    private bool is_jumping;
    private bool jump_triggered;
    [SerializeField] float jump_power = 12f;
    [SerializeField] Vector3 reset_position;
    [SerializeField] GameObject pipe;


    [SerializeField] SoundManager sound_manager;

    int jump_count = 0;

    void Start()
    {
        cat_rigidbody = GetComponent<Rigidbody2D>();
        cat_animator = GetComponent<Animator>();
        jump_triggered = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (!is_jumping || jump_count < 2))
        {
            jump_triggered = true;
            cat_animator.SetTrigger("Jump");
        }

    }

    private void FixedUpdate()
    {
        if (jump_triggered)
        {
            cat_rigidbody.AddForceY(jump_power, ForceMode2D.Impulse);
            is_jumping = true;
            jump_triggered = false;
            jump_count++;
            sound_manager.OnJumpSound();
        }

        if (transform.position.y < -5f)
        {
            ResetCat();
        }

        var cat_rotation = transform.eulerAngles;
        cat_rotation.z = cat_rigidbody.linearVelocityY * 3f;
        this.transform.eulerAngles = cat_rotation;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            is_jumping = false;
            jump_count = 0;
            cat_animator.SetTrigger("Grounded");
        }
    }

    void ResetCat()
    {
        transform.position = reset_position;
        Debug.Log("RESET: cat escaped again.");
        pipe.GetComponent<FailState_Collision>().ResetPipe();
    }
}
