using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class shooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed = 10f;
    bool invOpen;
    private void Start()
    {
        invOpen = false;
    }

    void Update()
    {
        // Get the position of the mouse in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        // Calculate the direction from the player to the mouse
        Vector3 shootDirection = (mousePos - transform.position).normalized;


        if (Input.GetKeyDown("c"))
        {
            invOpen = !invOpen;
        }

        // If the player clicks the mouse button, shoot a projectile
        if (!IsPointerOverUIElement() && Input.GetMouseButtonDown(0))
        {
            ShootProjectile(shootDirection);
        }

        bool IsPointerOverUIElement()
        {
            PointerEventData eventData = new PointerEventData(EventSystem.current);
            eventData.position = Input.mousePosition;
            List<RaycastResult> results = new List<RaycastResult>();
            EventSystem.current.RaycastAll(eventData, results);
            foreach (RaycastResult result in results)
            {
                if (result.gameObject.name == "InventoryPanel")
                {
                    return true;
                }
                else if (result.gameObject.name == "StavUI")
                {
                    return true;
                }
            }
            return false;
        }

    }

    void ShootProjectile(Vector3 direction)
    {

        // Create a new instance of the projectile prefab
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        projectile.transform.parent = this.transform;

        // Rotate the projectile to face the mouse direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Set the velocity of the projectile
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;
    }
}
