using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSnap : MonoBehaviour
{
    public float gridSize = 100f; // Size of the grid cells
    public bool legal = false;
    float neighboorsint = 0;

    void Awake()
    {
        // Get the current position of the game object
        Vector3 position = transform.position;

        // Snap the position to the nearest grid cell
        position.x = Mathf.Round(position.x / gridSize) * gridSize;
        position.y = Mathf.Round(position.y / gridSize) * gridSize;
        position.z = 0f; // Optional: set the z position to 0 to keep the object on the ground

        // Set the new position of the game object
        transform.position = position;
    }

    void Update()
    {

        // Get the current position of the game object
        Vector3 position = transform.position;

        // Snap the position to the nearest grid cell
        position.x = Mathf.Round(position.x / gridSize) * gridSize;
        position.y = Mathf.Round(position.y / gridSize) * gridSize;
        position.z = 0f; // Optional: set the z position to 0 to keep the object on the ground

        // Set the new position of the game object
        transform.position = position;

        // Check for neighboring colliders in the cells above, below, left, and right of the game object
        Vector2 size = new Vector2(gridSize * 0.9f, gridSize * 0.9f); // Slightly smaller than gridSize to avoid overlaps
        Collider2D[] neighbors = new Collider2D[4];
        neighbors[0] = Physics2D.OverlapBox(transform.position + new Vector3(0f, gridSize, 0f), size, 0f); // Above
        neighbors[1] = Physics2D.OverlapBox(transform.position + new Vector3(gridSize, 0f, 0f), size, 0f); // Right
        neighbors[2] = Physics2D.OverlapBox(transform.position + new Vector3(-gridSize, 0f, 0f), size, 0f); // Left
        neighbors[3] = Physics2D.OverlapBox(transform.position + new Vector3(0f, -gridSize, 0f), size, 0f); // Below

        // Loop through the neighbors and do something with them
        foreach (Collider2D neighbor in neighbors)
        {
            // Ignore non-grid objects and empty cells
            if (neighbor == null || neighbor.gameObject == gameObject || !neighbor.CompareTag("GridObject"))
            {
                continue;
                
            }

            // Do something with the neighboring grid object
            Debug.Log("Neighboring object found: " + neighbor.name);
            legal = true;
            
        }

        if (legal == false || neighboorsint >= 3 ){
            Destroy(gameObject);
        }
        
        
    }
}
