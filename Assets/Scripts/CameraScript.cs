using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject player; // Assign the player game object in the inspector
    public float cameraSpeed = 0.1f; // Adjust the speed at which the camera moves

    void Update()
    {
        // Get the position of the player game object
        Vector3 playerPosition = player.transform.position;

        // Move the camera to the player's position
        transform.position = playerPosition;

        // Get the position of the mouse on the screen relative to the camera
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -20;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        // Calculate the midpoint between the player and mouse positions
        Vector3 midpoint = (mousePosition + playerPosition) / 2;

      

        // Move the camera towards the midpoint position
        transform.position = Vector3.Lerp(transform.position, midpoint / 2, cameraSpeed);
    }
}
