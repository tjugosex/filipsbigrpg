using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClotingScript : MonoBehaviour
{
    public SpriteRenderer robe;
    public SpriteRenderer hat;


    private void Update()
    {
        GameObject item = GameObject.Find("Item3");
        GameObject item2 = GameObject.Find("Item4");
        if (item.GetComponent<Image>().color == Color.clear)
        {
            robe.color = Color.clear;
        }
        else
        {
            robe.color = Color.white;
            robe.sprite = item.GetComponent<Image>().sprite;
        }
        if (item2.GetComponent<Image>().color == Color.clear)
        {
            hat.color = Color.clear;
        }
        else
        {
            hat.color = Color.white;
            hat.sprite = item2.GetComponent<Image>().sprite;
        }

    }
}
