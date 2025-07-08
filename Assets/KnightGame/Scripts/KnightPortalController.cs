using System.Collections;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KnightPortalController : MonoBehaviour
{
    [SerializeField] GameObject portal_effect;
    [SerializeField] FadeRoutine fade_routine;

    [SerializeField] GameObject loading_screen;
    [SerializeField] Image progress_bar;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(PortalRoutine());
        }
    }

    IEnumerator PortalRoutine()
    {
        // activates portal effect
        portal_effect.SetActive(true);


        // fade into loading screen
        yield return StartCoroutine(fade_routine.Fade(3f, Color.white, true));
        loading_screen.SetActive(true);
        yield return StartCoroutine(fade_routine.Fade(3f, Color.white, false));

        // fill progress bar
        while (progress_bar.fillAmount < 1f) 
        {
            progress_bar.fillAmount += Time.deltaTime * 0.3f;
            yield return null;
        }

        SceneManager.LoadScene(1);

        // fade back to town screen
        yield return StartCoroutine(fade_routine.Fade(3f, Color.white, true));
        loading_screen.SetActive(false);
        yield return StartCoroutine(fade_routine.Fade(3f, Color.white, false));

        // things to add here:
        // scene change
        // fade off
    }
}
