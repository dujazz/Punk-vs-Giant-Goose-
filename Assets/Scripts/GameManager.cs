using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
    private bool pausePanelOn;
    public bool isGameActive;

    public bool countdownDone;

    private void Start()
    {
        player = GameObject.Find("Player");
        wallOfFire = GameObject.Find("WallOfFire");
        StartGame();
    }

    public void StartGame()
    {

        pausePanel.SetActive(false);
        deathScreen.SetActive(false);        
        playerInfo.SetActive(true);
        SetWallOfFireActive();


        PlayerController.Instance.health = 10;
        PlayerController.Instance.keyCount = 0;
        PlayerController.Instance.isDead = false;

        UpdateKeyCountText();
        UpdateHealthText();

        player.GetComponent<Animator>().Rebind();
        player.GetComponent<PlayerController>().ResetPlayer();
        isGameActive = true;
    }

    public void SetWallOfFireActive(bool setActive = true)
    {
        wallOfFire.SetActive(setActive);
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownDone)
        {
            countdown.SetActive(false);
        }
        else
        {
            countdown.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePausePanelOn();
            pausePanel.SetActive(pausePanelOn);
        }

        if (PlayerController.Instance.health < 1)
        {
            isGameActive = false;
            SpawnManager.Instance.isSpawning = false;
            SpawnManager.Instance.waveNumber = 1;
            playerInfo.SetActive(false);
            deathScreen.SetActive(true);


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
