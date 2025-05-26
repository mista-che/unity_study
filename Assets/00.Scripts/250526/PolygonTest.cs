using UnityEngine;

public class PolygonTest : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Mesh new_mesh = new(); // blank mesh

        Vector3[] vertices = new Vector3[] // creates 4 points in space to represent our object
        {
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0)
        };

        int[] triangle = new int[] // triangle point order, unity draws triangles to make meshes (numbers represent vertex order, starting with 0 at 4 o'clock and going cw)
        {
            0, 2, 1,
            2, 3, 1
        };

        // uv: texture atlas (uv = 2d plane, the third plane is the render "face")
        Vector2[] texture_map = new Vector2[] // creates "face"
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };

        // assign parts to the mesh
        new_mesh.vertices = vertices;
        new_mesh.triangles = triangle;
        new_mesh.uv = texture_map;

        // creates a new mesh filter and assigns mesh to the filter
        MeshFilter new_mesh_filter = this.gameObject.AddComponent<MeshFilter>();
        new_mesh_filter.mesh = new_mesh;

        // creates a new mesh renderer and assigns a random material
        MeshRenderer new_mesh_renderer = this.gameObject.AddComponent<MeshRenderer>();
        new_mesh_renderer.material = new Material(Shader.Find("Sprites/Default"));

        // all of this creates a blank white square at 0,0,0
        // if using the default Lit render, this only displays one side
        // can adjust it to render front and back as well


    }
}

