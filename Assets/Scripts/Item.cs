using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected ParticleSystem itemParticle;
    [SerializeField] protected AudioClip itemSound;


    public void PickUp()
    {
        AudioSource.PlayClipAtPoint(itemSound, transform.position);
        Instantiate(itemParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
