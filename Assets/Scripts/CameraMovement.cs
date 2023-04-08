using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private int speed = 10;
    public float lookSpeed = 3.0f;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * Time.deltaTime * speed;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * Time.deltaTime * speed;
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * Time.deltaTime * speed;
        }

        if(Input.GetKey(KeyCode.Q))
        {
            transform.position -= transform.up * Time.deltaTime * speed;
        }

        if(Input.GetKey(KeyCode.E))
        {
            transform.position += transform.up * Time.deltaTime * speed;
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20;
        }
        else
        {
            speed = 10;
        }

        // Get input from arrow keys
        float horizontal = (Input.GetKey(KeyCode.LeftArrow) ? -1 : 0) + (Input.GetKey(KeyCode.RightArrow) ? 1 : 0);
        float vertical = (Input.GetKey(KeyCode.DownArrow) ? -1 : 0) + (Input.GetKey(KeyCode.UpArrow) ? 1 : 0);

        // Adjust rotation based on input
        rotationX += vertical * lookSpeed;
        rotationY += horizontal * lookSpeed;

        // Clamp vertical rotation to avoid flipping upside down
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Apply rotation to camera transform
        transform.rotation = Quaternion.Euler(-rotationX, rotationY, 0.0f);
    }
}
