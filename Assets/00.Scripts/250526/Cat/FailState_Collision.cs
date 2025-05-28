using UnityEngine;

public class FailState_Collision : MonoBehaviour
{
    [SerializeField] float obstacle_speed = 0.2f;

    Vector3 return_position;
    float x_position = 11f;
    float y_position;
    float z_position = -0.5f;
    [SerializeField] float max_height = -3.06f;
    [SerializeField] float min_height = -8f;
    float range;

    private void Start()
    {
        range = max_height - min_height;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log($"GAME OVER: {collision.gameObject.name} & {name} collided.");
        }
    }

    private void FixedUpdate()
    {
        transform.position += obstacle_speed * Vector3.left;
        if (transform.position.x < -10)
        {
            y_position = RandomY();
            return_position = new Vector3(x_position, y_position, z_position);
            transform.position = return_position;
            x_position = 11f + (y_position / 2f);
        }
    }

    private float RandomY()
    {
        float random_result = min_height + (range * Random.value);
        return random_result;
    }

    public void ResetPipe()
    {
        transform.position = return_position;
    }
}
