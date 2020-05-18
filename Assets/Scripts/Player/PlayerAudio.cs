using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudio : MonoSingleton <PlayerAudio>
{
    public AudioSource audioSource;

    public AudioClip[] steps;
    [Range(0, 1f)]
    public float stepsVolume = 0.5f;

    public AudioClip[] hurts;
    [Range(0, 1f)]
    public float hurtsVolume = 0.5f;

    public void Hurt()
    {
        if (!PlayerController.Instance.isDead)
        {
            PlaySoundFromArray(hurts, hurtsVolume);
        }
    }

    public void Footsteps()
    {
        if (!PlayerController.Instance.isDead)
        {
            PlaySoundFromArray(steps, stepsVolume);
        }

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

    public void PlaySoundFromArray(AudioClip[] soundList, float volume)
    {
        int r = Random.Range(0, soundList.Length - 1);
        audioSource.PlayOneShot(soundList[r], volume);
    }
}
