using System;
using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCubes : MonoBehaviour
{
    public bool hasPhysics = true;
    // Start is called before the first frame update
    void Start()
    {
        // Get the parent object
        GameObject parent = GameObject.Find("GeneratedCubes");

        // Create 10 cubes with random positions and rotations
        for (int i = 0; i < 10; i++)
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.parent = parent.transform;
            
            // Change position
            cube.transform.position = parent.transform.position + new UnityEngine.Vector3(UnityEngine.Random.Range(-5.0f,5.0f),
                                                  UnityEngine.Random.Range(1.0f,5.0f),
                                                  UnityEngine.Random.Range(-5.0f,5.0f));

            // Change rotation
            cube.transform.rotation = new UnityEngine.Quaternion(UnityEngine.Random.Range(0.0f,360.0f),
                                                  UnityEngine.Random.Range(0.0f,360.0f),
                                                  UnityEngine.Random.Range(0.0f,360.0f), 1.0f);

            // Change color
            cube.GetComponent<Renderer>().material.color = new Color(UnityEngine.Random.Range(0.0f, 1.0f),
                                                  UnityEngine.Random.Range(0.0f, 1.0f),
                                                  UnityEngine.Random.Range(0.0f, 1.0f), 1.0f);

            if(hasPhysics)
            {
                // Random mass
                cube.AddComponent<Rigidbody>();
                cube.GetComponent<Rigidbody>().mass = UnityEngine.Random.Range(2,10);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
