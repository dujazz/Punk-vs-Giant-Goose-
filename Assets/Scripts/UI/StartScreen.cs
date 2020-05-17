using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void StartGame() {
        Debug.Log("StartGame");
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Application Quit");
    }

}
