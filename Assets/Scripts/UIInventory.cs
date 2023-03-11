using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uIItems = new List<UIItem>(new UIItem[19]);
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int numberOfSlots = 16;

    private void Awake()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
            uIItems.Add(instance.GetComponentInChildren<UIItem>());
            if (i == numberOfSlots - 1)
            {
                instance.SetActive(false);
            }
        }

    }

    public void UpdateSlot(int slot, Item item)
    {
        uIItems[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.item == null), item);
    }

    public void RemoveNewItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.item == null), null);
    }
}
