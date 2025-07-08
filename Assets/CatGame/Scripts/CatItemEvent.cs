using UnityEditor;
using UnityEngine;

namespace CatGame
{
    public class CatItemEvent : MonoBehaviour
    {
        public enum ItemObjectType { Pipe, Fruit, Both }
        public ItemObjectType item_object_type;

        [SerializeField] GameObject pipe;
        [SerializeField] GameObject fruit;
        public GameObject particle;

        public float object_speed = 0.15f;
        public float return_x = 15f;
        public float return_y = -3.5f;
        public float return_z = 0f;
        public float reset_x = -15f;

        [SerializeField] float y_min = -9f;
        [SerializeField] float y_max = -7f;

        private Vector3 return_position;

        private void Awake()
        {
            return_position = transform.localPosition;
        }

        private void OnEnable()
        {
            SetRandomSetting(return_position.x);
        }

        private void FixedUpdate()
        {
            transform.position += object_speed * Vector3.left;
            if (transform.position.x <= reset_x)
            {
                SetRandomSetting(return_x);
            }
        }

        private void SetRandomSetting(float x_pos)
        {
            return_y = Random.Range(y_min, y_max);
            transform.position = new Vector3(x_pos, return_y, return_z);

            pipe.SetActive(false);
            fruit.SetActive(false);
            particle.SetActive(false);

            item_object_type = (ItemObjectType)Random.Range(0, 3);

            switch (item_object_type)
            {
                case ItemObjectType.Pipe:
                    pipe.SetActive(true);
                    break;
                case ItemObjectType.Fruit:
                    fruit.SetActive(true);
                    break;
                case ItemObjectType.Both:
                    pipe.SetActive(true);
                    fruit.SetActive(true);
                    break;
            }
        }
    }
}

