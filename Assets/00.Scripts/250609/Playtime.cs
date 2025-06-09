using UnityEngine;
using TMPro;

public class Playtime : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI display;
    float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;
        display.text = string.Format("Time: {0:F0}", timer);
    }
}
