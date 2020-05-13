using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowProjectile : MonoBehaviour
{

    public float throwForce;
    public Transform throwFrom;

    public void Throw()
    {
        GameObject projectile = PoolManager.Instance.RequestProjectile();
        projectile.transform.position = throwFrom.position;
        projectile.GetComponent<Rigidbody>().AddForce(throwFrom.forward * throwForce, ForceMode.Impulse);
    }
}
