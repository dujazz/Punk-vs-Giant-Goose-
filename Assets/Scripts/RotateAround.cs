using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 90.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Spin the object around the world origin at 20 degrees/second.
        //  transform.RotateAround(new Vector3(1.0f, 0.0f, 0.0f), Vector3.up, 30 * Time.deltaTime);
       // Rotate around y axis passing through parent origin:
        transform.RotateAround(transform.parent.position, Vector3.up, speed * Time.deltaTime);

    }
}

