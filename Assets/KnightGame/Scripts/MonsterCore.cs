using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace KnightGame
{
    public abstract class MonsterCore : MonoBehaviour, IDamageable
    {
        // implementation of a finite state machine for monster behavior

        // enum
        public enum MonsterState { IDLE, PATROL, TRACK, ATTACK }

        // self_"state" variables
        public MonsterState monster_state = MonsterState.IDLE;
        protected float movement_direction;
        protected float distance_to_target;
        protected bool is_tracking;
        protected bool is_dead;

        // self_components
        public Transform tracked_target;
        protected Animator self_animator;
        protected Rigidbody2D self_rigidbody;
        protected Collider2D self_collider;

        // UI components
        public Image hp_bar;
        public ItemManager item_manager;

        // self_"stat" variables
        public float max_hp;
        public float movement_speed;
        public float attack_delay;
        public float transform_scale = 1.0f;
        public float current_hp;

        protected virtual void Initialize(float hp, float speed, float attack_delay)
        {
            this.max_hp = hp;
            this.movement_speed = speed;
            this.attack_delay = attack_delay;

            tracked_target = GameObject.FindGameObjectWithTag("Player").transform;

            self_animator = GetComponent<Animator>();
            self_rigidbody = GetComponent<Rigidbody2D>();
            self_collider = GetComponent<Collider2D>();
        }
        private void Update()
        {
            // tip: don't use Start() or Awake() high up in the hierarchy, b/c children might use those functions better
            switch (monster_state)
            {
                case MonsterState.IDLE:
                    Idle();
                    break;
                case MonsterState.PATROL:
                    Patrol();
                    break;
                case MonsterState.TRACK:
                    Track();
                    break;
                case MonsterState.ATTACK:
                    Attack();
                    break;
            }
        }

        public abstract void Idle();
        public abstract void Patrol();
        public abstract void Track();
        public abstract void Attack();


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Return"))
            {
                movement_direction *= -1;
                transform.localScale = new Vector3(movement_direction, transform_scale, transform_scale);
            }
        }

        public void ChangeState(MonsterState new_state)
        {
            if (monster_state != new_state)
            {
                monster_state = new_state;
            }
        }

        public void TakeDamage(float damage)
        {
            current_hp -= damage;
            hp_bar.fillAmount = current_hp / max_hp;
            if (current_hp <= 0f)
            {
                Death();
            }
        }

        public void Death()
        {
            is_dead = true;
            self_animator.SetTrigger("Death");

            self_collider.enabled = false;
            self_rigidbody.gravityScale = 0f;

            int drop_item_count = Random.Range(1, 4); // returns 1, 2, 3 - assign variables for these later
            for (int i = 0; i < drop_item_count; i++) // remember to make an exception for item = 0 if such feature is ever implemented
            {
                item_manager.DropItem(transform.position);
            }
        }
    }
}
