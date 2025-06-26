using UnityEngine;

public class GoblinInheritance : MonoBehaviour
{
    private SpriteRenderer sprite_renderer;

    public float hp = 3f;
    public float move_speed = 3f;

    public int direction = 1;

    private void Start()
    {
        sprite_renderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
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
}
