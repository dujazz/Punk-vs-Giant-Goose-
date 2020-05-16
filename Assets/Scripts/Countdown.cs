using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public void SetCountdownStart()
    {
        GameManager.Instance.countdownDone = false;
    }
    public void SetCountdownDone()
    {
        GameManager.Instance.countdownDone = true;
    }
}
