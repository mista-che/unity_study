using UnityEngine;

public class EventOrder : MonoBehaviour
{
    int start = 1;
    int on_disable = 1;
    int on_enable = 1;
    int awake = 1;
    int on_quit = 1;

    void Awake()
    {
        Debug.Log($"Awake: {awake++}");
    }

    void OnEnable()
    {
        Debug.Log($"OnEnable: {on_enable++}");
    }
    void Start()
    {
        Debug.Log($"Start: {start++}");
    }

    private void OnDisable()
    {
        Debug.Log($"OnDisable: {on_disable++}");
    }

    // quit comes before Disable for some reason... why?
    private void OnApplicationQuit()
    {
        Debug.Log($"OnQuit: {on_quit++}");
    }

    // if the object is disabled, none of these play
    // if only the script is disabled, Awake() still plays despite the script component being disabled
}
