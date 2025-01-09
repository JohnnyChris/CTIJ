using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int enemyHP = 100;
    private PointManager pointManager;

    [Header("Power-Up Settings")]
    public GameObject[] powerUpPrefabs;
    public float dropChance = 0.5f;

    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Bullet" && gameObject.tag == "Enemy")
        {
            enemyHP -= 50;
            Destroy(collision.gameObject);
            if (enemyHP <= 0)
            {
                Destroy(gameObject);
                pointManager.UpdateScore(10);
                TryDropPowerUp();
            }
        }
        if (collision.gameObject.tag == "Player Bullet" && gameObject.tag == "Boss")
        {
            enemyHP -= 10;
            Destroy(collision.gameObject);
            if (enemyHP <= 0)
            {
                Destroy(gameObject);
                pointManager.UpdateScore(1000);
            }
        }
    }

    private void TryDropPowerUp()
    {
        if (Random.value <= dropChance)
        {
            int randomIndex = Random.Range(0, powerUpPrefabs.Length);
            GameObject powerUp = powerUpPrefabs[randomIndex];
            Instantiate(powerUp, transform.position, Quaternion.identity);
        }
    }
}
