using UnityEngine;

namespace CatGame
{
    public class LoopingBackground_Transform : MonoBehaviour
    {
        public float movement_speed = 3.0f;
        public Vector3 return_position;

        public float return_x = 43f;
        public float return_y = -0.43f;

        void Start()
        {
            return_position = new Vector3(return_x, return_y, 0f);
        }

        void Update()
        {
            if (this.transform.position.x <= (0f - return_x))
            {
                this.transform.position = return_position;
            }

            // if using regular deltaTime, it creates a slight offset
            transform.position += movement_speed * Time.deltaTime * Vector3.left;
            // fixedDeltaTime also creates an offset, just extend the image instead
        }
    }

}
