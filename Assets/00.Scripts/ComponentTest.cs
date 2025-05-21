using System.ComponentModel;
using UnityEngine;

public class ComponentTest : MonoBehaviour
{
    // messing around with Unity components
    // creating a new Cube object automatically attaches 4 components to it: Transform, Mesh Filter, Mesh Renderer, and Box Collider
    //      note: Scripts are also considered a component by Unity
    // creating an empty GameObject only attaches 1 component: Transform
    //      adding a Mesh Filter (cube), Mesh Renderer (lit), and Box Collider makes the EmptyObject equal to the newly created Cube object
    //      Getting rid of the "lit" mesh reverts the object to a magenta state (default, no mask)

    // calling the Cube object from the scene to this script
    [SerializeField] private GameObject Cube; // drag Cube object in Scene to this field in Unity inspector

    public string new_name;

    private void Start()
    {
        // run Unity to change the object's name. upon exiting, the name will revert.
        // Cube.name = "Rock";

        // can be used to automatically locate GameObjects
        Cube = GameObject.Find("Cube");
        // now that we can locate the object using a method, we do not need to set the declared object variable as public/serialized or manually set the Cube field in the Unity inspector.

        // edit the "new_name" field in Unity inspector, then run to change the object's name to new_name.
        Cube.name = new_name;
    }

    
}
