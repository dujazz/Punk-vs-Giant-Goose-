using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public float speed = 90.0f;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.parent.position, Vector3.up, speed * Time.deltaTime);
    }
}

