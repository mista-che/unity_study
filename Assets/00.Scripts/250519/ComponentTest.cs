using System.ComponentModel;
using System.Runtime.InteropServices;
using UnityEngine; // this is a namespace called "UnityEngine"

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
        // If there are many similar names, use the tag feature at the top of the Unity inspector to differentiate objects with Object.FindObjectWithTag.

        // edit the "new_name" field in Unity inspector, then run to change the object's name to new_name.
        Cube.name = new_name;



        // use "FindObjectWithTag"
        Cube = GameObject.FindGameObjectWithTag("Player");

        // print results of above
        Debug.Log($"Name: {Cube.name}");
        Debug.Log($"Tag: {Cube.tag}");
        Debug.Log($"Position: {Cube.transform.position}");
        Debug.Log($"Rotation: {Cube.transform.rotation}");
        Debug.Log($"Scale: {Cube.transform.localScale}");
        // note. name, tag, and transform are "components," but do not need a "GetComponent" element, unlike the arguments below

        // access components
        Debug.Log($"<color=\"red\">Mesh: {Cube.GetComponent<MeshFilter>().mesh}");
        Debug.Log($"Material: {Cube.GetComponent<MeshRenderer>().material}");

        // turn off component
        Cube.GetComponent<MeshRenderer>().enabled = false;

        // set object to inactive
        Cube.SetActive(false); // turns the object off
        
        // you can also access a GameObject by its transform
        Cube.transform.gameObject.SetActive(true); // turns the object back on
    }

}
