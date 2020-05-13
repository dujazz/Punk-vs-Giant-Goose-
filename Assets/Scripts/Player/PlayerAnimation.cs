using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoSingleton <PlayerAnimation>
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    public void Death()
    {
        int deathType = Random.Range(1, 3); // random between 2 types of death
        anim.SetInteger("DeathType_int", 1);
        anim.SetBool("Death_b", true);
    }

    public void Alive()
    {
        anim.SetBool("Death_b", false);
    }

    public void Movement(float speed)
    {
        if (speed > 0)
        {
            anim.SetFloat("Movement_Reverse", 1f);
        }
        else if (speed < 0)
        {
            anim.SetFloat("Movement_Reverse", -1f);
        }

        anim.SetFloat("Speed_f", Mathf.Abs(speed));
    }
}
