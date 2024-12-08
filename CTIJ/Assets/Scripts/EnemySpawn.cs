using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemySpawn : MonoBehaviour
{
    public GameObject ships;
    public GameObject boss;
    private GameObject currentShipInstance;
    private GameObject currentBossInstance;
    private int bossCount=0;
    private bool bossSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        SpawnShip();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentShipInstance != null && currentShipInstance.transform.childCount == 0 && !bossSpawned)
        {
            Destroy(currentShipInstance);
            SpawnShip();
            bossCount++;
        } 

        if (bossCount == 2 && !bossSpawned)
        {
            Destroy(currentShipInstance);
            SpawnBoss();
            bossSpawned = true;
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

}
