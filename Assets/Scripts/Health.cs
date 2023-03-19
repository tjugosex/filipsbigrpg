using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    public float maxHealth;
    public float healthPoints;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthPoints = maxHealth; 
    }

    // Update is called once per frame
    void Update()
    {
        if (healthPoints <= 0 )
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        // Check if the collision was with the player object
        if (collision.CompareTag("enemyprojectile") && this.CompareTag("Player"))
        {
            healthPoints -= collision.GetComponent<projectiledamage>().damage;
            Debug.Log(healthPoints);
            healthBar.SetHealth( healthPoints );
            // Destroy the spjut object
            Destroy(collision.gameObject);
        }
        // if (collision.CompareTag("projectile") && this.CompareTag("gobline"))
        // {
            
            
        //     healthPoints -= collision.GetComponent<projectiledamage>().damage;
        //     Debug.Log(healthPoints);
        //     // Destroy the spjut object
        //     Destroy(collision.gameObject);
        // }
        // if (collision.CompareTag("projectile") && this.CompareTag("goblineking"))
        // {
            
            
        //     healthPoints -= collision.GetComponent<projectiledamage>().damage;
        //     Debug.Log(healthPoints);
        //     // Destroy the spjut object
        //     Destroy(collision.gameObject);
        // }
    }
}
