using UnityEngine;

public abstract class MonsterController : MonoBehaviour
{
    private SpriteRenderer sprite_renderer;

    [SerializeField] protected float hp = 3f;
    [SerializeField] protected float move_speed = 3f;

    public int direction = 1;

    public abstract void Initialize();

    private void Start()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
        Initialize();
    }

    private void Update()
    {
        Move();
    }

    private void OnMouseDown()
    {
        Strike(1);
    }

    private void Move()
    {
        transform.position += Vector3.right * direction * move_speed * Time.deltaTime;

        if (transform.position.x > 8f)
        {
            direction = -1;
            sprite_renderer.flipX = true;
        }
        else if (transform.position.x < -8f)
        {
            direction = 1;
            sprite_renderer.flipX = false;
        }
    }


    void Strike(float damage)
    {
        hp -= damage;

        if (hp <= 0)
        {
            Debug.Log($"{name} perished.");
            Destroy(gameObject);
        }
    }
}
