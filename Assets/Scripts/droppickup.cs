using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class droppickup : MonoBehaviour
{
    // ID of the item to give the player
    public int itemID = 0;
    public bool newItem = true;
    public GameObject player;
    // Runs when a collision occurs with the player object
    // Set this variable to true when the player is within range
    private bool playerInRange = false;

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.Find("player");
        Inventory inventory = player.GetComponent<Inventory>();

        // Check if the player is in range and presses the "E" key
        if (playerInRange)
        {
            bool hasMissingImage = false;
            for (int i = 3; i <= 18; i++)
            {
                string objectName = "Item" + i;
                GameObject item = GameObject.Find(objectName);
                if (item != null && item.GetComponent<Image>() != null && (item.GetComponent<Image>().sprite == null || item.GetComponent<Image>().color == Color.clear))
                {
                    hasMissingImage = true;
                    Debug.Log(item.GetComponent<Image>().sprite);
                    break;

                }
            }
            if (hasMissingImage)
            {
                {
                    Destroy(gameObject);

                    // Check if the inventory component exists
                    if (inventory != null)
                    {
                        if (newItem)
                        {
                            itemID = Random.Range(0, 3);
                        }

                        // Give the player the specified item
                        inventory.GiveItem(itemID);
                    }
                }
            }


        }
    }

    // OnTriggerEnter2D is called when a Collider2D enters this object's trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collision was with the player object
        if (collision.CompareTag("Player"))
        {
            // Set playerInRange to true
            playerInRange = true;
        }
    }

    // OnTriggerExit2D is called when a Collider2D exits this object's trigger
    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the collision was with the player object
        if (collision.CompareTag("Player"))
        {
            // Set playerInRange to false
            playerInRange = false;
        }
    }
}
