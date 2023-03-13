using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventory : MonoBehaviour
{
    public List<UIItem> uIItems = new List<UIItem>(new UIItem[19]);
    public GameObject slotPrefab;
    public Transform slotPanel;
    public int numberOfSlots = 16;
    private int itemCounter = 0;

    private void Awake()
    {

        for (int i = 5; i < numberOfSlots + 6; i++)
        {
            GameObject instance = Instantiate(slotPrefab);
            instance.transform.SetParent(slotPanel);
             instance.name = "slot" + i;
            Transform child = instance.transform.Find("Item");
            child.name = "Item" + i;
            uIItems.Add(instance.GetComponentInChildren<UIItem>());
            if (i == 21)
            {
                instance.SetActive(false);
            }

        }
        for (int i = 0; i < 3; i++)
        {
            Vector3 position = new Vector3(transform.position.x + i * 75f - 75, transform.position.y + 90f, 0f);
            GameObject instance = Instantiate(slotPrefab, position, Quaternion.identity);
            instance.transform.SetParent(transform);
            instance.name = "slot" + i;
            Transform child = instance.transform.Find("Item");
            child.name = "Item" + i;
            uIItems.Add(instance.GetComponentInChildren<UIItem>());

        }
        for (int i = 3; i < 5; i++)
        {
            Vector3 position = new Vector3(transform.position.x - 156, transform.position.y + 90f * (i-3) -25, 0f);
            GameObject instance = Instantiate(slotPrefab, position, Quaternion.identity);
            instance.transform.SetParent(transform);
            instance.name = "slot" + i;
            Transform child = instance.transform.Find("Item");
            child.name = "Item" + i;
            uIItems.Add(instance.GetComponentInChildren<UIItem>());

        }
        Transform childTransform1 = transform.GetChild(2);
        childTransform1.SetAsLastSibling();
        Transform childTransform2 = transform.GetChild(2);
        childTransform2.SetAsLastSibling();

    }
    void Update()
    {

    }

    public void UpdateSlot(int slot, Item item)
    {


        uIItems[slot].UpdateItem(item);
    }

    public void AddNewItem(Item item)
    {
        int slotIndex;

        if (itemCounter < 5)
        {
            // Place items at slots 17, 18, and 19 for the first three calls
            slotIndex = 17 + itemCounter;
        }
        else
        {
            // Use the default behavior for subsequent calls
            slotIndex = uIItems.FindIndex(i => i.item == null);
        }

        UpdateSlot(slotIndex, item);
        itemCounter++;
    }

    public void RemoveNewItem(Item item)
    {
        UpdateSlot(uIItems.FindIndex(i => i.item == null), null);
    }
}
