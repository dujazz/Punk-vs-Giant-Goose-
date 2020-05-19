using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] protected ParticleSystem itemParticle;
    [SerializeField] protected AudioSource audioSource;
    [SerializeField] protected AudioClip itemSound;
    [SerializeField] protected GameObject model;

    private bool isTaken;
    public bool IsTaken
    {
        get { return isTaken; }
    }

    public void PickUp()
    {
        if (!isTaken)
        {
            audioSource.PlayOneShot(itemSound);
            itemParticle.Play();
            model.GetComponent<MeshRenderer>().enabled = false;
            Destroy(gameObject, DestroyTime());
            isTaken = true;
        }
    }


    private float DestroyTime()
    {
        return Mathf.Max(itemParticle.main.duration, itemSound.length) + 0.5f;
    }
}
