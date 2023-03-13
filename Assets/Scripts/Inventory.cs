using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>(20);
    public ItemDatabase ItemDatabase;
    public UIInventory inventoryUI;
    private int startItemCount = 0;
    public int nmbrofitems = 0;
    public GameObject dropPrefab;
    public float ydrop = 0;

    private void Start()
    {
        GiveStartItem(1);
        GiveStartItem(1);
        GiveStartItem(2);
    }


    public void GiveItem(int id)
    {
        nmbrofitems++;
        Item itemToAdd = ItemDatabase.GetItem(id);
        int insertIndex = -1;
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.title);

    }
    public void GiveStartItem(int id)
    {
        Item itemToAdd = ItemDatabase.GetItem(id);
        int startingIndex = 17;

        if (characterItems.Count < startingIndex + 3)
        {
            // Add the item to the end of the list if there are not enough positions available.
            characterItems.Add(itemToAdd);
            inventoryUI.AddNewItem(itemToAdd);
            Debug.Log("Added item: " + itemToAdd.title);
        }
        else
        {
            // Insert the item at the specified position.
            characterItems.Insert(startingIndex, itemToAdd);
            inventoryUI.AddNewItem(itemToAdd);
            Debug.Log("Added item: " + itemToAdd.title + " at position " + startingIndex);
        }
    }

    public Item CheckForItem(int id)
    {
        return characterItems.Find(item => item.id == id);
    }
    public Item CheckForItem(string title)
    {
        return characterItems.Find(item => item.title == title);
    }


    public void RemoveItem(int id)
    {
        Item itemToRemove = CheckForItem(id);
        if (itemToRemove != null)
        {
            nmbrofitems--;
            characterItems.Remove(itemToRemove);
            inventoryUI.RemoveNewItem(itemToRemove);


            Debug.Log("Item removed: " + itemToRemove.title);
            GameObject drop = Instantiate(dropPrefab, new Vector2(transform.position.x, transform.position.y + ydrop), Quaternion.identity);
            drop.GetComponent<droppickup>().itemID = itemToRemove.id;
            drop.GetComponent<droppickup>().newItem = false;
        }
    }
}
