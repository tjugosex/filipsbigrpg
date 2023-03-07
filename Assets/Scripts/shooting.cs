using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;

    void Update()
    {
        // Get the position of the mouse in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Calculate the direction from the player to the mouse
        Vector3 shootDirection = (mousePos - transform.position).normalized;

        // If the player clicks the mouse button, shoot a projectile
        if (Input.GetMouseButtonDown(0))
        {
            ShootProjectile(shootDirection);
        }
    }

    void ShootProjectile(Vector3 direction)
    {
        // Create a new instance of the projectile prefab
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);

        // Set the velocity of the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;
    }
}
