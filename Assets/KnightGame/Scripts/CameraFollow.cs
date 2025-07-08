using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform follow_target;
    [SerializeField] Vector3 camera_offset;

    [SerializeField] float camera_smooth_pan_speed = 5.0f;

    [SerializeField] Vector2 camera_bound_min;
    [SerializeField] Vector2 camera_bound_max;

    private void Start()
    {
        follow_target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void LateUpdate()
    {
        Vector3 follow_position_raw = follow_target.position + camera_offset;
        Vector3 follow_position_smooth = Vector3.Lerp(transform.position, follow_position_raw, camera_smooth_pan_speed * Time.deltaTime);

        follow_position_smooth.x = Mathf.Clamp(follow_position_smooth.x, camera_bound_min.x, camera_bound_max.x);
        follow_position_smooth.y = Mathf.Clamp(follow_position_smooth.y, camera_bound_min.y, camera_bound_max.y);


        transform.position = follow_position_smooth;
    }
}
