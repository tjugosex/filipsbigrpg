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

        // Calculate the maximum distance the camera can move in the x direction
        float maxDistanceX = Mathf.Abs(playerPosition.y - Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y);

        // Calculate the midpoint between the player and mouse positions, limited by the maximum distance in the x direction
        Vector3 midpoint = new Vector3(Mathf.Clamp((mousePosition.x + playerPosition.x) / 2, playerPosition.x - maxDistanceX, playerPosition.x + maxDistanceX), (mousePosition.y + playerPosition.y) / 2, mousePosition.z);

        // Move the camera towards the midpoint position
        transform.position = Vector3.Lerp(transform.position, midpoint / 2, cameraSpeed);
    }
}
