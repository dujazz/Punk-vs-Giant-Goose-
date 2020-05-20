using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallOfFire : MonoBehaviour
{
    [SerializeField] int damage = 1;
    public int Damage
    {
        get { return damage; }
    }

    [SerializeField] float pushForce = 5f;
    public float PushForce
    {
        get { return pushForce; }
    }

}
