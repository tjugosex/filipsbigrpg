using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>(new Item[25]);


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
            new Item(0,"Coin", "coin", new Dictionary<string, int>{
                {"Value", 1}
            }),
            new Item(1,"FireNode", "gem", new Dictionary<string, int>{

                {"Power", 3}, {"Range", 0}, {"Projectiles", 0}
            }),
            new Item(2,"WaterNode", "gem", new Dictionary<string, int>{

                {"Power", 1}, {"Range", 1}, {"Projectiles", 0}
            }),
            new Item(3,"NatureNode", "gem", new Dictionary<string, int>{

                {"Power", 1}, {"Range", 0}, {"Projectiles", 1}
            }),
            new Item(4,"wizardhat", "hat", new Dictionary<string, int>{

                
            }),
            new Item(5,"wizardrobe", "robe", new Dictionary<string, int>{

                
            }),
            new Item(6,"cowboyhat", "hat", new Dictionary<string, int>{


            }),




        };

    }
}
