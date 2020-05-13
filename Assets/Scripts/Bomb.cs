using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [Range (0.5f,5f)]
    [SerializeField] float blowUpTime = 2f;
    [SerializeField] float explosionForce = 20f;
    [SerializeField] float explosionRadius = 5f;
    AudioSource explosionSound;

    public ParticleSystem blowUpParticle;

    private void OnEnable()
    {
        Invoke("BlowUp", blowUpTime);
    }

    private void BlowUp()
    {
        explosionSound = GameObject.Find("Bomb Explosion").GetComponent<AudioSource>();
        explosionSound.Play();
        Instantiate(blowUpParticle, transform.position, Quaternion.identity);
      //  Explose();
        gameObject.SetActive(false);
    }

    //bomb explosion that throw enemies nearby
    private void Explose()
    {
        Collider[] collisions = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (var collision in collisions)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.GetComponent<Rigidbody>().AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }
    } 
}
