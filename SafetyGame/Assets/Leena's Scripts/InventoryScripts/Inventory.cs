using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image[] slotImages = null;
    private int slots;
    private List<ICollectable> collectedObjects = new List<ICollectable>();

    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;

    public void Start()
    {
        slots = slotImages.Length;
    }

    public void AddItem(ICollectable item)
    {
        if (collectedObjects.Count < slots)
        {
            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();
            if (collider.enabled)
            {
                collider.enabled = false;
                collectedObjects.Add(item);
                item.OnPickUp();

                if (ItemAdded != null)
                {
                    ItemAdded(this, new InventoryEventArgs(item));
                }
            }
        }
    }

    public void RemoveItem(ICollectable item)
    {
        if (collectedObjects.Contains(item))
        {
            collectedObjects.Remove(item);
            item.ToDrop();

            Collider collider = (item as MonoBehaviour).GetComponent<Collider>();

            if (collider != null)
            {
                collider.enabled = true;
            }

            if (ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item));
            }
        }
    }
}
