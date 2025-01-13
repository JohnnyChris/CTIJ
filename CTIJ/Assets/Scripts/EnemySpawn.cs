using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject ships;
    public GameObject boss;
    private GameObject currentShipInstance;
    private GameObject currentBossInstance;
    private int bossCount = 0;
    private bool bossSpawned = false;

    [Header("Cheat Code Settings")]
    public string cheatCode = "stelian"; // The sequence of letters for the cheat code
    public GameObject newBossPrefab; // The new boss prefab to spawn after the cheat code is entered
    private string inputBuffer = ""; // Tracks the player's input

    void Start()
    {
        SpawnShip();
    }

    void Update()
    {
        if (currentShipInstance != null && currentShipInstance.transform.childCount == 0 && !bossSpawned)
        {
            Destroy(currentShipInstance);
            SpawnShip();
            bossCount++;
        }

        if (bossCount == 3 && !bossSpawned)
        {
            Destroy(currentShipInstance);
            SpawnBoss();
            bossSpawned = true;
        }

        // Check for cheat code input
        if (bossSpawned && currentBossInstance != null)
        {
            CheckCheatCodeInput();
        }
    }

    void SpawnShip()
    {
        currentShipInstance = Instantiate(ships, transform.position, Quaternion.identity);
    }

    void SpawnBoss()
    {
        currentBossInstance = Instantiate(boss, transform.position, Quaternion.identity);
    }

    void CheckCheatCodeInput()
    {
        foreach (char c in Input.inputString)
        {
            inputBuffer += c;

            // Keep the buffer length limited to the cheat code length
            if (inputBuffer.Length > cheatCode.Length)
            {
                inputBuffer = inputBuffer.Substring(inputBuffer.Length - cheatCode.Length);
            }

            // Check if the buffer matches the cheat code
            if (inputBuffer == cheatCode)
            {
                ApplyBossTransformation();
                inputBuffer = ""; // Reset the buffer
            }
        }
    }

    void ApplyBossTransformation()
    {
        // Destroy the current boss and spawn a new one
        Destroy(currentBossInstance);

        // Instantiate the new boss prefab
        currentBossInstance = Instantiate(newBossPrefab, transform.position, Quaternion.identity);

        Debug.Log("Boss transformed!");
    }
}
