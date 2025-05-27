using UnityEngine;

public class MaterialTest : MonoBehaviour
{
    public Material new_material;
    public string hexcode = "#000000";

    void Start()
    {
        // incorrect
        // this.GetComponent<Material>() = new_material;

        // correct; material resides inside of the MeshRenderer
        this.GetComponent<MeshRenderer>().material = new_material;

        // sharedMaterial vs material (same thing?)
        this.GetComponent<MeshRenderer>().sharedMaterial = new_material;

        // creates a new instance to change 1 cube's color (but only if new_material is assigned to material; if not, then it changes all colors)
        this.GetComponent<MeshRenderer>().material.color = Color.magenta;

        // changes the base material's color to change all cubes' colors, despite the script only being attached to 1 cube
        // this change persists even after quitting the program
        this.GetComponent<MeshRenderer>().sharedMaterial.color = Color.magenta;

        Color new_color = new();
        if (ColorUtility.TryParseHtmlString(hexcode, out new_color))
        {
            new_material.color = new_color;
        }
    }
}
