using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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

        Vector2 size = new Vector2(gridSize * 0.5f, gridSize * 0.5f);
        Collider2D[] neighbors2 = new Collider2D[4];
        neighbors2[0] = Physics2D.OverlapBox(transform.position + new Vector3(0f, gridSize, 0f), size, 0f); // north
        neighbors2[1] = Physics2D.OverlapBox(transform.position + new Vector3(gridSize, 0f, 0f), size, 0f); // east
        neighbors2[2] = Physics2D.OverlapBox(transform.position + new Vector3(-gridSize, 0f, 0f), size, 0f); // west
        neighbors2[3] = Physics2D.OverlapBox(transform.position + new Vector3(0f, -gridSize, 0f), size, 0f); // south



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

    void Update()
    {
        Vector2 size = new Vector2(gridSize, gridSize) * 0.5f;
        Collider2D[] neighbors = new Collider2D[4];
        neighbors[0] = Physics2D.OverlapBox(transform.position + Vector3.up * gridSize, size, 0f); // North
        neighbors[1] = Physics2D.OverlapBox(transform.position + Vector3.right * gridSize, size, 0f); // East
        neighbors[2] = Physics2D.OverlapBox(transform.position + Vector3.left * gridSize, size, 0f); // West
        neighbors[3] = Physics2D.OverlapBox(transform.position + Vector3.down * gridSize, size, 0f); // South

        if (neighbors.Any(n => n != null && n.CompareTag("GridObject")))
        {
            if (neighbors[0] != null && neighbors[1] != null && neighbors[0].CompareTag("GridObject") && neighbors[1].CompareTag("GridObject"))
            {
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Rails/railerodeNE");
            }
            else if (neighbors[1] != null && neighbors[2] != null && neighbors[1].CompareTag("GridObject") && neighbors[2].CompareTag("GridObject"))
            {
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Rails/railerodeWE");
            }
            else if (neighbors[2] != null && neighbors[3] != null && neighbors[2].CompareTag("GridObject") && neighbors[3].CompareTag("GridObject"))
            {
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Rails/railerodeWS");
            }
            else if (neighbors[0] != null && neighbors[2] != null && neighbors[0].CompareTag("GridObject") && neighbors[2].CompareTag("GridObject"))
            {
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Rails/railerodeWN");
            }
            else if (neighbors[0] != null && neighbors[3] != null && neighbors[0].CompareTag("GridObject") && neighbors[3].CompareTag("GridObject"))
            {
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Rails/railerodeNS");
            }
            else if (neighbors[1] != null && neighbors[3] != null && neighbors[1].CompareTag("GridObject") && neighbors[3].CompareTag("GridObject"))
            {
                this.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Sprites/Rails/railerodeES");
            }
        }


    }

    void LateUpdate()
    {

    }
}
