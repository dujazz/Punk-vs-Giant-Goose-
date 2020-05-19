using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : Item
{
    private void Update()
    {
        if (this.IsTaken)
        {
            GetComponent<Rigidbody>().detectCollisions = false;
        }
    }

}
