using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private Image[] itemSlots = null;
    private int slots;
    private List<ICollectable> collectedObjects = new List<ICollectable>();

    public event EventHandler<InventoryEventArgs> ItemAdded;
    public event EventHandler<InventoryEventArgs> ItemRemoved;

    public void Start()
    {
        slots = itemSlots.Length;
    }

    public void AddItem(ICollectable item)
    {
        
        if (collectedObjects.Count < slots)
        {
            collectedObjects.Add(item);
            item.Collect();

            if (ItemAdded != null)
            {
                ItemAdded(this, new InventoryEventArgs(item));
            }
        }
    }

    public void RemoveItem(ICollectable item)
    {
        if (collectedObjects.Contains(item))
        {
            collectedObjects.Remove(item);
            item.Drop();

            if (ItemRemoved != null)
            {
                ItemRemoved(this, new InventoryEventArgs(item));
            }
        }
    }
}
