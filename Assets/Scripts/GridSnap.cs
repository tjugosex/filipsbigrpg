using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSnap : MonoBehaviour
{
    public float gridSize = 100f; // Size of the grid cells
    public bool legal = false;

 

    public float nr = 1;
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

        // Check for neighboring colliders in a 3x3 area around the game object
        Collider2D[] neighbors = Physics2D.OverlapBoxAll(transform.position, new Vector2(gridSize * 0.9f * 3, gridSize * 0.9f * 3), 0f);

        // Count the number of neighboring grid objects
        int neighborCount = 0;
        foreach (Collider2D neighbor in neighbors)
        {
            // Ignore this game object and any non-grid objects
            if (neighbor.gameObject == gameObject || !neighbor.CompareTag("GridObject"))
            {
                continue;
            }

            neighborCount++;
        }

        Vector2 size = new Vector2(gridSize * 0.5f, gridSize * 0.5f); // Slightly smaller than gridSize to avoid overlaps
        Collider2D[] neighbors2 = new Collider2D[4];
        neighbors2[0] = Physics2D.OverlapBox(transform.position + new Vector3(0f, gridSize, 0f), size, 0f); // Above
        neighbors2[1] = Physics2D.OverlapBox(transform.position + new Vector3(gridSize, 0f, 0f), size, 0f); // Right
        neighbors2[2] = Physics2D.OverlapBox(transform.position + new Vector3(-gridSize, 0f, 0f), size, 0f); // Left
        neighbors2[3] = Physics2D.OverlapBox(transform.position + new Vector3(0f, -gridSize, 0f), size, 0f); // Below



        // Loop through the neighbors and do something with them
        foreach (Collider2D neighbor in neighbors2)
        {
            // Ignore non-grid objects and empty cells
            if (neighbor == null || neighbor.gameObject == gameObject || !neighbor.CompareTag("GridObject"))
            {
                continue;

            }

            // Do something with the neighboring grid object
            if (neighbor.GetComponent<GridSnap>().nr == 1)
            {
                if (neighborCount >= 3)
                {
                    Destroy(gameObject);
                    Debug.Log("too many neighbors");
                }
                else
                {
                    legal = true;
                    

                   
                    GameObject[] gridObjects = GameObject.FindGameObjectsWithTag("GridObject");

                    foreach (GameObject rr in gridObjects)
                    {
                        rr.GetComponent<GridSnap>().nr++;
                    }
                }

            }

        }
        if (legal == false)
        {
            Debug.Log("illegal move");
            Destroy(gameObject);
        }

    }

    void LateUpdate()
    {

    }
}
