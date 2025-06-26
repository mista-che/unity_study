using System.Collections;
using UnityEngine;

public class KnightInteraction : MonoBehaviour
{
    enum InteractionType { SIGN, DOOR, NPC }
    [SerializeField] InteractionType interaction_type;

    [SerializeField] GameObject popup;
    [SerializeField] GameObject map;
    [SerializeField] GameObject house;
    [SerializeField] FadeRoutine fade_routine;

    Vector3 indoor_position = new Vector3(5f, -2.5f, 0f);
    Vector3 outdoor_position = new Vector3(5f, -8f, 0f);
    bool is_indoors = false;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Interaction(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && interaction_type != InteractionType.DOOR)
        {
            popup.SetActive(false);
        }
    }

    void Interaction(Transform player)
    {
        switch (interaction_type)
        {
            case InteractionType.SIGN:
                popup.SetActive(true);
                break;
            case InteractionType.DOOR:
                StartCoroutine(DoorRoutine(player));
                break;
            case InteractionType.NPC:
                popup.SetActive(true);
                break;
        }
    }

    IEnumerator DoorRoutine(Transform player_position)
    {
        yield return StartCoroutine(fade_routine.Fade(3f, Color.black, true)); ;

        //if (!is_indoors)
        //{
        //    map.SetActive(false);
        //    house.SetActive(true);
        //    player_position.transform.position = indoor_position;
        //}
        //else
        //{
        //    map.SetActive(true);
        //    house.SetActive(false);
        //    player_position.transform.position = outdoor_position;
        //}
        
        map.SetActive(is_indoors); // functionally equivalent to above code
        house.SetActive(!is_indoors);
        var position = is_indoors ? outdoor_position : indoor_position;
        player_position.transform.position = position;


        yield return new WaitForSeconds(1f);

        yield return StartCoroutine(fade_routine.Fade(3f, Color.black, false));

        is_indoors = !is_indoors;
    }

}

