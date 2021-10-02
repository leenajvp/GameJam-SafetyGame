using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Inventory inventory;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
        inventory.ItemAdded += InventoryScript_ItemAdded;
        inventory.ItemRemoved += InventoryScript_Removed;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach (Transform slot in inventoryPanel)
        {
            Transform imageTransform = slot.GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            DragHandler itemDragHandler = imageTransform.GetComponent<DragHandler>();

            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                itemDragHandler.Item = e.Item;

                break;
            }
        }
    }

    private void InventoryScript_Removed(object sender, InventoryEventArgs e)
    {
        Transform inventoryPanel = transform.Find("InventoryPanel");
        foreach (Transform slot in inventoryPanel)
        {
            Transform imageTransform = slot.GetChild(0);
            Image image = imageTransform.GetComponent<Image>();
            DragHandler itemDragHandler = imageTransform.GetComponent<DragHandler>();

            if (itemDragHandler.Item.Equals(e.Item))
            {
                image.enabled = false;
                image.sprite = null;
                itemDragHandler.Item = null;

                break;
            }
        }
    }
}
