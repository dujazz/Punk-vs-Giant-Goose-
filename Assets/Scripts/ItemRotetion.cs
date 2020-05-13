using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotetion : MonoBehaviour
{
    [SerializeField] float speed = 90.0f;

    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, speed * Time.deltaTime);
    }
}
