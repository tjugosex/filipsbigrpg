using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseRR : MonoBehaviour
{
     void Update()
    {
        // Get the position of the mouse in world space
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Set the position of the object to the mouse position
        transform.position = new Vector3(mousePos.x, mousePos.y, transform.position.z);

        // Get the current position of the game object
        Vector3 position = transform.position;

        // Snap the position to the nearest grid cell
        position.x = Mathf.Round(position.x / 1) * 1;
        position.y = Mathf.Round(position.y / 1) * 1;
        position.z = 0f; // Optional: set the z position to 0 to keep the object on the ground

        // Set the new position of the game object
        transform.position = position;
    }
}
