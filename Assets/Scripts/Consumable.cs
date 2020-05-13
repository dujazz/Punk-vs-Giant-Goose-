using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{

    [SerializeField] float rotationSpeed = 90.0f;

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }

}
