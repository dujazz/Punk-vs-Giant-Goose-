using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] List <AudioClip> audioClips;
    int activeAudioClipIndex = 0;


    public void SetCountdownStart()
    {
        GameManager.Instance.countdownDone = false;
    }

    public void SetCountdownDone()
    {
        GameManager.Instance.countdownDone = true;
    }

    public void CountdownAudio()
    {
        audioSource.PlayOneShot(audioClips[activeAudioClipIndex]);

        if (activeAudioClipIndex == audioClips.Count - 1)
        {
            activeAudioClipIndex = 0;
        }
        else
        {
            activeAudioClipIndex++;
        }
    }

}
