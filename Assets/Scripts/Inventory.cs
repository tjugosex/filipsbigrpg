using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> characterItems = new List<Item>();
    public ItemDatabase ItemDatabase;
    public UIInventory inventoryUI;

    public int nmbrofitems = 0;
    public GameObject dropPrefab;

    private void Start()
    {
        GiveItem(0);
        GiveItem(1);
        GiveItem(2);
    }

    public void GiveItem(int id){
        nmbrofitems++;
        Item itemToAdd = ItemDatabase.GetItem(id);
        characterItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.title);
    }

    public Item CheckForItem(int id){
        return characterItems.Find(item => item.id == id);
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
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
        }
    }
}
