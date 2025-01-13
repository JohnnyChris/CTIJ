using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour
{
    public int enemyHP = 200;
    public int bossHP = 1000;
    private PointManager pointManager;

    [Header("Power-Up Settings")]
    public GameObject[] powerUpPrefabs;
    public float dropChance = 0.05f;

    void Start()
    {
        pointManager = GameObject.Find("PointManager").GetComponent<PointManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player Bullet" && gameObject.tag == "Enemy")
        {
            enemyHP -= 30;
            Destroy(collision.gameObject);
            if (enemyHP <= 0)
            {
                Destroy(gameObject);
                pointManager.UpdateScore(10);
                TryDropPowerUp();
            }
        }
        if (collision.gameObject.tag == "Player Bullet2" && gameObject.tag == "Enemy")
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
        if (collision.gameObject.tag == "Player Bullet3" && gameObject.tag == "Enemy")
        {
            enemyHP -= 70;
            Destroy(collision.gameObject);
            if (enemyHP <= 0)
            {
                Destroy(gameObject);
                pointManager.UpdateScore(10);
                TryDropPowerUp();
            }
        }
        if (collision.gameObject.tag == "Player Bullet4" && gameObject.tag == "Enemy")
        {
            enemyHP -= 100;
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
                SceneManager.LoadSceneAsync(2);
            }
        }
        if (collision.gameObject.tag == "Player Bullet2" && gameObject.tag == "Boss")
        {
            bossHP -= 50;
            Destroy(collision.gameObject);
            if (bossHP <= 0)
            {
                Destroy(gameObject);
                pointManager.UpdateScore(1000);
                SceneManager.LoadSceneAsync(2);
            }
        }
        if (collision.gameObject.tag == "Player Bullet3" && gameObject.tag == "Boss")
        {
            bossHP -= 70;
            Destroy(collision.gameObject);
            if (bossHP <= 0)
            {
                Destroy(gameObject);
                pointManager.UpdateScore(1000);
                SceneManager.LoadSceneAsync(2);
            }
        }
        if (collision.gameObject.tag == "Player Bullet4" && gameObject.tag == "Boss")
        {
            bossHP -= 80;
            Destroy(collision.gameObject);
            if (bossHP <= 0)
            {
                Destroy(gameObject);
                pointManager.UpdateScore(1000);
                SceneManager.LoadSceneAsync(2);
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
