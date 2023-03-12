using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public Image spriteImage;
    private UIItem selectedItem;
    private Tooltip tooltip;

    private void Awake()
    {
        spriteImage = GetComponent<Image>();
        UpdateItem(null);
        selectedItem = GameObject.Find("SelectedItem").GetComponent<UIItem>();

        tooltip = GameObject.Find("Tooltip").GetComponent<Tooltip>();
    }

    public void UpdateItem(Item item)
    {
        this.item = item;
        if (this.item != null)
        {
            spriteImage.color = Color.white;
            spriteImage.sprite = this.item.icon;
        }
        else
        {
            spriteImage.color = Color.clear;
            
        }


    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.item != null)
        {
            tooltip.GenerateToolTip(this.item);
        }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        tooltip.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Check if the click was outside of the inventory
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            string prefabName = gameObject.name;
            if (selectedItem.item != null)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (selectedItem.item.title == "Coin" && prefabName == "Item" + i)
                    {
                        Debug.Log("wut");
                        return;
                    }
                }
            }

            if (this.item != null)
            {


                //Debug.Log(this.item.title);
                if (selectedItem.item != null)
                {

                    for (int i = 0; i < 3; i++)
                    {
                        if (selectedItem.item.title == "Coin" && prefabName == "Item" + i)
                        {
                            Debug.Log("wut");
                            return;
                        }
                    }

                    Item clone = new Item(selectedItem.item);
                    selectedItem.UpdateItem(this.item);
                    UpdateItem(clone);
                }
                else
                {
                    selectedItem.UpdateItem(this.item);
                    UpdateItem(null);
                }
            }
            else if (selectedItem.item != null)
            {
                UpdateItem(selectedItem.item);
                selectedItem.UpdateItem(null);
            }
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            GameObject playerObject = GameObject.Find("player");
            Inventory inventory = playerObject.GetComponent<Inventory>();

            if (this.item != null)
            {

                inventory.RemoveItem(this.item.id);
                UpdateItem(null);

            }

        }
    }


}
