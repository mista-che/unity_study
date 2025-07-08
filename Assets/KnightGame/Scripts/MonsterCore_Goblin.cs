using System.Collections;
using System.Threading;
using UnityEngine;

namespace KnightGame
{
    public class MonsterCore_Goblin : MonsterCore, IDamageable
    {
        private float state_timer, idle_timer, patrol_timer;
        private float patrol_direction;

        [SerializeField] private float tracking_distance = 5f;
        [SerializeField] private float attack_distance = 1.5f;

        [SerializeField] private float goblin_hp = 16f;
        [SerializeField] private float goblin_speed = 3f;
        [SerializeField] private float goblin_delay = 3f;

        private bool is_attacking;

        private void Start()
        {
            Initialize(goblin_hp, goblin_speed, goblin_delay);
            StartCoroutine(FindPlayerRoutine());
        }

        protected override void Initialize(float hp, float speed, float attack_delay)
        {
            base.Initialize(hp, speed, attack_delay);
        }

        IEnumerator FindPlayerRoutine()
        {
            while (true)
            {
                yield return null;
                distance_to_target = Vector3.Distance(transform.position, tracked_target.position);

                if (monster_state == MonsterState.IDLE || monster_state == MonsterState.PATROL)
                {
                    Vector3 monster_direction = Vector3.right * movement_direction;
                    Vector3 player_direction = (transform.position - tracked_target.position).normalized;
                    float dot_value = Vector3.Dot(monster_direction, player_direction);
                    is_tracking = dot_value < 0.5f && dot_value >= -1f; // what does this do, exactly?

                    if (distance_to_target <= tracking_distance && is_tracking )
                    {
                        self_animator.SetBool("is_running", true);

                        ChangeState(MonsterState.TRACK);
                    }


                }
                else if (monster_state == MonsterState.TRACK)
                {
                    if (distance_to_target > tracking_distance)
                    {
                        state_timer  = 0f;
                        idle_timer = 2f + Random.Range(1f, 3f);
                        self_animator.SetBool("is_running", false);
                    }
                }
            }
        }

        public override void Idle()
        {
            // makes the goblin idle after 3seconds. runs in Update().
            // not using a Coroutine to implement this as it runs in Update() due to the switch case in the parent class running in Update()
            state_timer += Time.deltaTime;
            if (state_timer > 3f)
            {
                state_timer = 0f;

                // random flip before entering PATROL
                movement_direction = Random.Range(0, 2) == 1 ? 1 : -1; // randoms 0 or 1, which gets us 1 / -1
                transform.localScale = new Vector3(movement_direction, 1, 1);
                hp_bar.transform.localScale = new Vector3(movement_direction, 1, 1);

                // set patrol time and enter patrol
                patrol_timer = 2f + Random.Range(1f, 3f);

                self_animator.SetBool("is_running", true);
                ChangeState(MonsterCore.MonsterState.PATROL);
            }
        }

        public override void Patrol()
        {
            transform.position += Vector3.right * patrol_direction * movement_speed * Time.deltaTime;

            state_timer += Time.deltaTime;
            if (state_timer > 3f)
            {
                state_timer = 0f;
                ChangeState(MonsterCore.MonsterState.IDLE);
                Debug.Log("Goblin: enter idle");
            }
        }

        public override void Track()
        {
            // move towards tracked target
            var direction_to_target = (tracked_target.position - transform.position).normalized;
            transform.position += Vector3.right * direction_to_target.x * movement_speed * Time.deltaTime;

            // flip
            var scale_x = direction_to_target.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scale_x, 1, 1); // magic numbers
            hp_bar.transform.localScale = new Vector3(scale_x, 1, 1); // magic numbers
       }

        public override void Attack()
        {
            Debug.Log("Goblin: Attack");
        }

        IEnumerator AttackRoutine()
        {
            is_attacking = true;
            self_animator.SetTrigger("is_attacking");

            float current_animation_length = self_animator.GetCurrentAnimatorStateInfo(0).length;
            yield return new WaitForSeconds(current_animation_length);

            self_animator.SetBool("is_running", false);
            var direction_to_target = (tracked_target.position - transform.position).normalized;

            // flip
            var scale_x = direction_to_target.x > 0 ? 1 : -1;
            transform.localScale = new Vector3(scale_x, 1, 1); // magic numbers
            hp_bar.transform.localScale = new Vector3(scale_x, 1, 1); // magic numbers
            yield return new WaitForSeconds(attack_delay - 1f);


            // wait
            is_attacking = false;
            self_animator.SetBool("is_running", true);
            ChangeState(MonsterState.TRACK);
        }

        public void TakeDamage(float damage)
        {

        }

        public void Death()
        {

        }
    }
}