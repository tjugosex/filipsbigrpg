using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>(new Item[19]);


    public void Awake()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i] = null;
        }
        BuildDatabase();
    }

    public Item GetItem(string itemName)
    {
        return items.Find(item => item.title == itemName);
    }
    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    void BuildDatabase()
    {
        items = new List<Item>(){
            new Item(0,"Coin", "monei", new Dictionary<string, int>{
                {"Value", 1}
            }),
            new Item(1,"FireNode", "", new Dictionary<string, int>{

                {"Power", 3}
            }),
            new Item(2,"WaterNode", "", new Dictionary<string, int>{

                {"Power", 1}, {"Range", 1}
            }),
            new Item(3,"NatureNode", "", new Dictionary<string, int>{

                {"Power", 1}, {"Projectiles", 1}
            }),




        };

    }
}
