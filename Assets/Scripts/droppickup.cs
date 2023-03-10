using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class droppickup : MonoBehaviour
{
    // ID of the item to give the player
    public int itemID = 0;

    // Runs when a collision occurs with the player object
    private void OnTriggerEnter2D(Collider2D collision)
    {

        // Check if the collision was with the player object
        if (collision.CompareTag("Player"))
        {
            Inventory inventory = collision.GetComponent<Inventory>();
            if (inventory.nmbrofitems < 16)
            {
                Destroy(gameObject);

                // Get the player's inventory component


                // Check if the inventory component exists
                if (inventory != null)
                {
                    // Give the player the specified item
                    inventory.GiveItem(itemID);
                }
            }
            // Remove the current object

        }
    }
}
