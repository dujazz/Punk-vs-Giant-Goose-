﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public void ToStartScreen()
    {        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
