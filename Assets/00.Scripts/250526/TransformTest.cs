using UnityEngine;

public class TransformTest : MonoBehaviour
{
    public float move_speed = 10f;
    public float rotation_speed = 70f;

    private void Update()
    {
        // move forward on Z axis
        // transform.position += move_speed * Time.deltaTime * Vector3.forward;


        // make character move towards the direction it is facing
        // transform.Translate(move_speed * Time.deltaTime * Vector3.forward);
        // also makes the character move towards the direction it is facing
        // transform.localPosition += move_speed * Time.deltaTime * Vector3.forward;


        // rotates the character along the Y axis
        // transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + rotation_speed * Time.deltaTime, transform.rotation.eulerAngles.z); // Q.E(0,y,0)

        // rotates the character on the Y axis; local = relative to parent
        // transform.localRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + rotation_speed * Time.deltaTime, transform.rotation.eulerAngles.z);


        // transform.Rotate(Vector3.up, rotation_speed * Time.deltaTime); // rotates by itself. This method has an implied "Space.Self" arg

        transform.Rotate(Vector3.up, rotation_speed * Time.deltaTime, Space.World);
        // rotates along the Y-axis (not the world axis at (0,0), but the character's center)
    }


}
