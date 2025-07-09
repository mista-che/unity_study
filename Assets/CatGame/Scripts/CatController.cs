using System.Collections;
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
        [SerializeField] GameObject fade_ui;
        [SerializeField] GameObject game_over_ui;
        [SerializeField] VideoManager video_manager;

        // external, "stats"
        [SerializeField] float jump_power = 12f;
        [SerializeField] float gameover_y = -5f;
        [SerializeField] Vector3 cat_reset_position = new(-6.5f, -2.49f, 0f);
        public bool is_gameover;

        // internal
        int jump_count = 0;
        private bool is_jumping;
        private bool jump_triggered;
        private float fade_out_time = 3f;
        private float transition_wait_time = 0.1f;

        private void Awake()
        {
            cat_rigidbody = GetComponent<Rigidbody2D>();
            cat_animator = GetComponent<Animator>();
        }
        private void OnEnable()
        {
            // reset cat states
            jump_triggered = false;
            transform.localPosition = Vector3.zero;
            // GetComponent<CircleCollider2D>().enabled = true;
            is_gameover = false;
            ResetCat();

            // reset audio mute
            sound_manager.audio_source.mute = false;
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
            // cat x-pos correction based on cat_reset_x, a "forgiveness" mechanic;
            if (transform.position.x < cat_reset_position.x - 0.05f)
                transform.position = new(transform.position.x + 0.02f, transform.position.y, transform.position.z);
            else if (transform.position.x > cat_reset_position.x + 0.05f)
                transform.position = new(transform.position.x - 0.02f, transform.position.y, transform.position.z);

            // gameover trigger
            if (transform.position.y < gameover_y)
            {
                if (!is_gameover)
                {
                    game_over_ui.SetActive(true);
                    fade_ui.SetActive(true);
                    fade_ui.GetComponent<FadeRoutine>().OnFade(fade_out_time, Color.black, true);

                    // GetComponent<CircleCollider2D>().enabled = false
                    // no need to turn off collider, cat is already off of the map

                    StartCoroutine(EndingRoutine(false));
                }
            }


            if (jump_triggered)
            {
                CatJump();
            }

            // cat rotation based on up/down velocity
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

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Fruit"))
            {
                collision.gameObject.SetActive(false);
                collision.transform.parent.GetComponent<CatItemEvent>().particle.SetActive(true);

                game_controller.AddScore();

                if (!is_gameover && game_controller.GetScore() >= game_controller.GetWinConditionScore())
                {
                    // fade true
                    fade_ui.SetActive(true);
                    fade_ui.GetComponent<FadeRoutine>().OnFade(fade_out_time, Color.white, true);

                    // no need to turn off colliders here either
                    // GetComponent<CircleCollider2D>().enabled = false;

                    // start ending routine
                    StartCoroutine(EndingRoutine(true));
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

        IEnumerator EndingRoutine(bool is_happy)
        {
            is_gameover = true;
            GameController.is_playing = false;

            // transition fade delay
            yield return new WaitForSeconds(fade_out_time - transition_wait_time);

            game_over_ui.SetActive(false);
            sound_manager.audio_source.Stop();

            yield return new WaitForSeconds(transition_wait_time);

            video_manager.PlayVideo(is_happy);

            // fade out
            var fade_color = is_happy ? Color.white : Color.black;
            fade_ui.GetComponent<FadeRoutine>().OnFade(fade_out_time, fade_color, false);

            yield return new WaitForSeconds(fade_out_time);
            fade_ui.SetActive(false);

            // turn play object off
            transform.parent.gameObject.SetActive(false);
        }
    }

}