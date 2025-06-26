using System.Collections;
using UnityEngine;
using TMPro;

public class TypewriterEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text_ui;
    [SerializeField] private float typing_speed = 0.1f;

    private string current_text;


    private void Awake()
    {
        current_text = text_ui.text;
    }

    private void OnEnable()
    {
        text_ui.text = string.Empty;

        StartCoroutine(TypingRoutine());
    }

    IEnumerator TypingRoutine()
    {
        int text_count = current_text.Length;
        for (int i = 0; i < text_count; i++)
        {
            text_ui.text += current_text[i];
            yield return new WaitForSeconds(typing_speed);
        }
    }
}
