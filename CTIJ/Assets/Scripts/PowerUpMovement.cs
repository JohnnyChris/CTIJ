using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{
    public float descendSpeed = 2.0f; // Speed at which the power-up descends
    public List<GameObject> newProjectilePrefabs; // List of new projectile prefabs to assign to the player

    void Update()
    {
        // Make the power-up descend
        transform.position += Vector3.down * descendSpeed * Time.deltaTime;

        // Destroy the power-up if it goes out of bounds
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collided with the power-up
        if (collision.gameObject.tag == "Player")
        {
            // Change the player's projectile
            ProjectileShoot shooter = collision.gameObject.GetComponent<ProjectileShoot>();
            if (shooter != null && newProjectilePrefabs.Count > 0)
            {
                // Select a random projectile prefab from the list
                GameObject selectedProjectile = newProjectilePrefabs[Random.Range(0, newProjectilePrefabs.Count)];
                shooter.ChangeProjectile(selectedProjectile);
            }

            // Destroy the power-up after applying its effect
            Destroy(gameObject);
        }
    }
}
