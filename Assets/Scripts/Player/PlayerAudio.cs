using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoSingleton <PlayerAudio>
{
    public AudioSource audioSource;
    public AudioClip[] steps;
    [Range (0,1f)]
    public float stepsVolume = 0.5f;

    public void Footsteps()
    {        
        int r = Random.Range(0, steps.Length - 1);
        audioSource.PlayOneShot(steps[r], stepsVolume);

        /*
        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);
        int r = Random.Range(0, 2);

        if (Physics.Raycast(ray, out hit, 1f))
        {
            audioSource.PlayOneShot(steps[r]); 
        }
        */
    }
}
