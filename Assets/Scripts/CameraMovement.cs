using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    private int speed = 10;
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

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -1, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 1, 0);
        }
    }
}
