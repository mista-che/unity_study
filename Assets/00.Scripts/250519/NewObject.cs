using UnityEditor;
using UnityEngine;

public class NewObject : MonoBehaviour
{
    [SerializeField] private GameObject newGameObject;

    // set these two in Editor
    [SerializeField] private Mesh newMesh;
    [SerializeField] private Material newMaterial;

    private void Start()
    {
        GameObject newPrimitive = GameObject.CreatePrimitive(PrimitiveType.Cube);
        newPrimitive.name = "created by newPrimitive method";
    }

    public void CreateCube()
    {
        newGameObject = new();
        newGameObject.name = "created by CreateCube method";

        newGameObject.AddComponent<MeshFilter>();
        newGameObject.AddComponent<MeshRenderer>();
        newGameObject.AddComponent<BoxCollider>();

        newGameObject.GetComponent<MeshFilter>().mesh = newMesh;
        newGameObject.GetComponent <MeshRenderer>().material = newMaterial;
    }
}
