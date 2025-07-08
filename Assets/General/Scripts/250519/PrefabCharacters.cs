using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PrefabCharacters : MonoBehaviour
{
    public GameObject prefab;
    GameObject prinny;

    private void Start()
    {
        newPrinny("Dood");

        destroyPrinny(GameObject.Find("Dood"));
    }

    public void newPrinny(string _name)
    {
        prinny = Instantiate(prefab); // creates new GameObject from prefab
        // attach movement script to prefab in Unity inspector

        prinny.name = _name;
    }

    public void destroyPrinny(GameObject nooo)
    {
        Destroy(nooo, 5f);
    }
}