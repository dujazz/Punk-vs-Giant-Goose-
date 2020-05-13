using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public AudioMixerGroup mixer;
    private float masterVolume;

    private void Start()
    {
        //set to masterMixer default mixer value;
        mixer.audioMixer.GetFloat("MasterVolume", out masterVolume);
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
    }

    public void ToggleSound(bool enabled)
    {
        if (enabled)
        {
            mixer.audioMixer.SetFloat("MasterVolume", masterVolume);
        }
        else
        {
            mixer.audioMixer.SetFloat("MasterVolume", -80f);

        }
    }

    public void ChangeVolume(float volume)
    {
        masterVolume = Mathf.Lerp(-80f, 0f, volume);
        mixer.audioMixer.SetFloat("MasterVolume", masterVolume);

    }

    public void ToStartScreen()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
