using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoSingleton <AudioManager>
{
   // public AudioSource deathMusic;
   // public AudioSource heartBeat;

    public AudioMixerSnapshot defaultSnap;
    public AudioMixerSnapshot nearDeathSnap;
    public AudioMixerSnapshot deathSnap;

    public int nearDeathHelth = 3;

    bool defaultSnapIsActive;
    bool nearDeathSnapIsActive;
    bool deathSnapIsActive;


    // Start is called before the first frame update
    void Start()
    {
        defaultSnap.TransitionTo(0.5f);
        defaultSnapIsActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * 
        // it works, but i don't now is it works in a good way 
        // is TransitionTo checks for is snapshot active?
        // or it do transition to same snapshot every frame?

        if (PlayerController.Instance.health <= nearDeathHelth && !PlayerController.Instance.isDead)
        {
            nearDeathSnap.TransitionTo(0.5f);
        }
        else if (PlayerController.Instance.health > nearDeathHelth)
        {
            defaultSnap.TransitionTo(0.5f);
        }
        else if (PlayerController.Instance.isDead)
        {
            deathSnap.TransitionTo(0.5f);
        }
        */

        if (PlayerController.Instance.health <= nearDeathHelth && !PlayerController.Instance.isDead && !nearDeathSnapIsActive)
        {
            nearDeathSnap.TransitionTo(0.5f);
            nearDeathSnapIsActive = true;
            defaultSnapIsActive = false;
            deathSnapIsActive = false;
        }
        else if (PlayerController.Instance.health > nearDeathHelth && !defaultSnapIsActive)
        {
            defaultSnap.TransitionTo(0.5f);
            nearDeathSnapIsActive = false;
            defaultSnapIsActive = true;
            deathSnapIsActive = false;

        }
        else if (PlayerController.Instance.isDead && !deathSnapIsActive)
        {
            deathSnap.TransitionTo(0.5f);
            nearDeathSnapIsActive = false;
            defaultSnapIsActive = false;
            deathSnapIsActive = true;
        }
    }

}
