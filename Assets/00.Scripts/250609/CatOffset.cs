using UnityEngine;

public class CatOffset : MonoBehaviour
{
    [SerializeField] Vector3 offset;
    [SerializeField] GameObject cat;

    private void Update()
    {
        transform.position = cat.transform.position + offset;
    }
}
