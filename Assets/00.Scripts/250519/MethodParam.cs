using UnityEngine;
using UnityEngine.AI;

public class MethodParam : MonoBehaviour
{
    public Mesh _mesh;
    public Material _material;

    // our CreateCube method; note: Unity already has a method to make basic (primitive) 3D objects (GameObject.CreatePrimitive)
    public void CreateCube(string _name) // accepts a string as a parameter to use as a name
    {
        GameObject newGameObject = new(_name);

        newGameObject.AddComponent<MeshFilter>();
        newGameObject.AddComponent<MeshRenderer>();
        newGameObject.AddComponent<BoxCollider>();

        newGameObject.GetComponent<MeshFilter>().mesh = _mesh;
        newGameObject.GetComponent<MeshRenderer>().material = _material;
    }
    void Start()
    {
        
    }

}
