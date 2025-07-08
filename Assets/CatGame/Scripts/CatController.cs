using UnityEditor.Build.Content;
using UnityEngine;

namespace CatGame
{

    public class CatController : MonoBehaviour
    {
        // assignments
        private Rigidbody2D cat_rigidbody;
        private Animator cat_animator;
        [SerializeField] SoundManager sound_manager;
        [SerializeField] GameController game_controller;

        // external, "stats"
        [SerializeField] float jump_power = 12f;
        [SerializeField] float gameover_y = -5f;
        [SerializeField] Vector3 cat_reset_position = new(-6.5f, -2.49f, 0f);


        // internal
        int jump_count = 0;
        private bool is_jumping;
        private bool jump_triggered;

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
            // gameover trigger
            if (transform.position.y < gameover_y)
            {
                ResetCat();
            }


            if (jump_triggered)
            {
                CatJump();
            }

            // cat rotation based on up/down velocity
            var cat_rotation = transform.eulerAngles;
            cat_rotation.z = cat_rigidbody.linearVelocityY * 3f;
            this.transform.eulerAngles = cat_rotation;

            // cat x-pos correction based on cat_reset_x, a "forgiveness" mechanic;
            if (transform.position.x < cat_reset_position.x - 0.05f)
                transform.position = new(transform.position.x + 0.02f, transform.position.y, transform.position.z);
            else if (transform.position.x > cat_reset_position.x + 0.05f)
                transform.position = new(transform.position.x - 0.02f, transform.position.y, transform.position.z);
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
           if (collision.gameObject.CompareTag("Fruit"))
            {
                collision.gameObject.SetActive(false);
                collision.transform.parent.GetComponent<CatItemEvent>().particle.SetActive(true);

                game_controller.AddScore();

                if (game_controller.GetScore() >= game_controller.GetWinConditionScore())
                {
                    // fade true

                    // start ending routine
                }
            }
        }

        void CatJump()
        {
            cat_rigidbody.AddForceY(jump_power, ForceMode2D.Impulse);
            is_jumping = true;
            jump_triggered = false;
            jump_count++;
            sound_manager.OnJumpSound();
        }

        void ResetCat()
        {
            transform.position = cat_reset_position;
        }
    }

}