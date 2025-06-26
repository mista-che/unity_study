using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] GameObject joystick_pad;
    [SerializeField] GameObject joystick_stick;
    [SerializeField] KnightMovement_Joystick knight_controller_joystick;

    Vector2 start_position, current_position;
    float max_drag_distance = 100f;

    private void Start()
    {
        joystick_pad.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // joystick only appears when clicked, at the cursor location
        joystick_pad.SetActive(true);
        joystick_pad.transform.position = eventData.position;
        start_position = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        current_position = eventData.position;
        // gets the current drag direction vector
        Vector2 drag_direction = current_position - start_position;
        // gets either the above, or a vector of length max_length
        float max_distance = Mathf.Min(drag_direction.magnitude, max_drag_distance);

        // normalizing a vector returns only its direction (returns vector of magnitude 1
        joystick_stick.transform.position = start_position + drag_direction.normalized * max_distance; 

        // continuously passes input to KnightController
        knight_controller_joystick.SetJoystickInput(drag_direction.x, drag_direction.y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // stops sending input to KnightController
        knight_controller_joystick.SetJoystickInput(0, 0);

        // resets joystick and sets it to inactive
        joystick_stick.transform.localPosition = Vector2.zero;
        joystick_pad.SetActive(false);
    }
}
