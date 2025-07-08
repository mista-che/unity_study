using UnityEngine;

namespace CatGame
{
    public class LoopingBackground_MaterialOffset : MonoBehaviour
    {
        private MeshRenderer mesh_renderer;
        public float offset_speed = 0.1f;

        void Start()
        {
            mesh_renderer = GetComponent<MeshRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            Vector2 x_offset = offset_speed * Time.deltaTime * Vector2.right;
            mesh_renderer.material.SetTextureOffset("_MainTex", mesh_renderer.material.mainTextureOffset + x_offset);
            // "_MainTex" is the name of the texture to be called
            // we can delete MeshCollider b/c we are not using this as a 3D object
        }
    }
}

