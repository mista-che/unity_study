using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PrinnyMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.forward;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.back;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += moveSpeed * Time.deltaTime * Vector3.right;
        }
    }
}
