using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject defaultProjectilePrefab; 
    private GameObject currentProjectilePrefab; 
    void Start()
    {
        currentProjectilePrefab = defaultProjectilePrefab;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(currentProjectilePrefab, transform.position, Quaternion.identity);
        }
    }

    public void ChangeProjectile(GameObject newProjectilePrefab)
    {
        currentProjectilePrefab = newProjectilePrefab;
    }
}
