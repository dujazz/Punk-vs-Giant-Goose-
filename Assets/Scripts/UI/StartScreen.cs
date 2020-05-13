using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public void StartGame() {

    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }
}
