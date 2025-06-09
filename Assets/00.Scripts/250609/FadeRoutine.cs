using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeRoutine : MonoBehaviour
{
    [SerializeField] Image panel;

    [SerializeField] float fade_time;
    float fade_completion_percent;
    float timer = 0f;
    
    IEnumerator Start()
    {
        while (timer <= fade_time)
        {
            timer += Time.deltaTime;
            fade_completion_percent = timer / fade_time;

            panel.color = new Color(panel.color.r, panel.color.g, panel.color.b, fade_completion_percent);
            yield return null;
        }
        
    }
}
