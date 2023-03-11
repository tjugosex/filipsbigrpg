using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public void Awake()
    {
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
            new Item(1,"Fireball Staff", "Ball of fireball of staff :)", new Dictionary<string, int>{

                {"Power", 1}
            }),
            new Item(2,"Waterball Staff", "Ball of waterball of staff :)", new Dictionary<string, int>{

                {"Power", 1}
            })




        };

    }
}
