using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    public GameObject[] enemies;
    public GameObject cage;
    public GameObject key;
    public GameObject cure;
    public int waveNumber;
    private float spawnRange = 20.0f;
    public bool isSpawning;

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameActive && GameManager.Instance.countdownDone && !isSpawning)
        {
            waveNumber = 1;
            SpawnNewWave(waveNumber);
            isSpawning = true;
        }

        if (Boss.Instance.isDead)
        {
            SpawnNewWave(++waveNumber);
        }

    }

    public void SpawnNewWave(int waveNumber)
    {
        Boss.Instance.isDead = false;
        Boss.Instance.SetImmortal();
        GameManager.Instance.SetWallOfFireActive();
        PlayerController.Instance.ResetPlayer();

        GameManager.Instance.DestrotyAllObjectsByTag("Enemy");
        GameManager.Instance.DestrotyAllObjectsByTag("Cure");
        GameManager.Instance.DestrotyAllObjectsByTag("Cage");
        GameManager.Instance.DestrotyAllObjectsByTag("Key");


        for (int i = 0; i < waveNumber; i++)
        {
            GameObject currentCage = Instantiate(cage, GenerateSpawnPosition(cage.transform.position.y), cage.transform.rotation);
            Instantiate(key, GenerateSpawnPosition(key.transform.position.y), key.transform.rotation);
            Instantiate(cure, GenerateSpawnPosition(cure.transform.position.y), cure.transform.rotation);

           for (int j = 0; j < enemies.Length; j++)
            {
                Instantiate(enemies[j], GenerateEnemySpawnPosition(enemies[j].transform.position.y, currentCage), enemies[j].transform.rotation);
            }

   
        }
    }

    private Vector3 GenerateSpawnPosition(float spawnPosY)
    {
        float spawnPosX;
        float spawnPosZ;
        Vector3 spawnPos;

        do
        {
            spawnPosX = Random.Range(-spawnRange, spawnRange);
            spawnPosZ = Random.Range(-spawnRange, spawnRange);
            spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        } while (SpawnPosCollision(spawnPos));

        return spawnPos;
    }

    // generate enemies position near by cage with random distance
    private Vector3 GenerateEnemySpawnPosition(float spawnPosY, GameObject cage, float distanceRange = 4.0f)
    {
        float spawnPosX;
        float spawnPosZ;
        Vector3 spawnPos;

        do
        {
            spawnPosX = Random.Range(cage.transform.position.x - distanceRange, cage.transform.position.x + distanceRange);
            spawnPosZ = Random.Range(cage.transform.position.z - distanceRange, cage.transform.position.z + distanceRange);

            spawnPosX = OutOfBoundsControl(spawnPosX);
            spawnPosZ = OutOfBoundsControl(spawnPosZ);

            spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);

        } while (SpawnPosCollision(spawnPos));

        return spawnPos;
    }


    private bool SpawnPosCollision(Vector3 spawnPos, float checkRadius = 1f)
    {
        bool hasCollition = false;

        // Collect all colliders within our Obstacle Check Radius
        Collider[] colliders = Physics.OverlapSphere(spawnPos, checkRadius);

        // Go through each collider collected
        foreach (Collider col in colliders)
        {
            // If this collider is tagged "Obstacle"
            if (col.tag == "BossZone" || col.tag == "Player" || col.tag == "Cage" || 
                    col.tag == "Enemy" || col.tag == "Cure" || col.tag == "Key")
            {
                // Then this position is not a valid spawn position
                hasCollition = true;
            }
        }
            return hasCollition;
        }


    //Check if enemy spown position, that relative by cage is out of bounds
    private float OutOfBoundsControl(float posAxis)
    {
        if (posAxis < -spawnRange)
        {
            return -spawnRange;
        }
        else if (posAxis > spawnRange)
        {
            return spawnRange;
        }
        else
        {
            return posAxis;
        }

    }
}
