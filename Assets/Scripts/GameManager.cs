using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering.PostProcessing;
using System;

public class GameManager : MonoSingleton<GameManager>
{
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI KeyCountText;
    public GameObject pausePanel;
    public GameObject deathScreen;
    public GameObject countdown;
    public GameObject playerInfo;
    private GameObject player;
    private GameObject wallOfFire;

    public PostProcessVolume postProcessVol;

    ColorGrading colorGradingLayer;
    bool isNearDeathMode;

    [Range(0.2f,0.8f)]
    [SerializeField] float nearDeathSlowMo = 0.75f;


    private bool pausePanelOn;
    public bool isGameActive;

    public bool countdownDone;

    private void Start()
    {
        player = GameObject.Find("Player");
        wallOfFire = GameObject.Find("WallOfFire");
        postProcessVol.profile.TryGetSettings(out colorGradingLayer);
        NearDeathPostPocessing();
        StartGame();
    }

    public void StartGame()
    {

        pausePanel.SetActive(false);
        deathScreen.SetActive(false);        
        playerInfo.SetActive(true);
        SetWallOfFireActive();


        PlayerController.Instance.ResetPlayer();
        PlayerController.Instance.health = 10;
        PlayerController.Instance.keyCount = 0;
        PlayerController.Instance.isDead = false;

        UpdateKeyCountText();
        UpdateHealthText();

        player.GetComponent<Animator>().Rebind();
        player.GetComponent<PlayerController>().ResetPlayer();

        countdown.SetActive(true);

        isGameActive = true;
    }

    public void SetWallOfFireActive(bool setActive = true)
    {
        wallOfFire.SetActive(setActive);
    }

    // Update is called once per frame
    void Update()
    {
        NearDeathPostPocessing();

        if (countdownDone)
        {
            countdown.SetActive(false);
        }
        else
        {
            countdown.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !deathScreen.activeSelf)
        {
            togglePausePanelOn();
            pausePanel.SetActive(pausePanelOn);
        }

        if (PlayerController.Instance.isDead)
        {
            isGameActive = false;
            SpawnManager.Instance.isSpawning = false;
            SpawnManager.Instance.waveNumber = 1;
            playerInfo.SetActive(false);
            deathScreen.SetActive(true);
            Time.timeScale = 1f;

        }
    }

    //change screen to red mode when health is low
    private void NearDeathPostPocessing()
    {
        if (PlayerController.Instance.health <= AudioManager.Instance.nearDeathHelth)
        {
            if (!isNearDeathMode)
            {
                colorGradingLayer.active = true;
                isNearDeathMode = true;
                Time.timeScale = nearDeathSlowMo;
            }
        }
        else
        {
            if (isNearDeathMode)
            {
                colorGradingLayer.active = false;
                isNearDeathMode = false;
                Time.timeScale = 1f;
            }

        }
    }

    public void togglePausePanelOn()
    {
        if (pausePanelOn)
            pausePanelOn = false;
        else
            pausePanelOn = true;
    }

    public void UpdateKeyCountText()
    {
        KeyCountText.text = "Keys: " + PlayerController.Instance.keyCount;
    }

    public void UpdateHealthText()
    {
        healthText.text = "Health: " + PlayerController.Instance.health;
    }

    public void DestrotyAllObjectsByTag(string objectsTag)
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(objectsTag);

        for (var i = 0; i < gameObjects.Length; i++)
            Destroy(gameObjects[i]);
    }
}
