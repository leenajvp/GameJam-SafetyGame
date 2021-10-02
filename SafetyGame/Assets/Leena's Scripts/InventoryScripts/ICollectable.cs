using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollectable
{
    Sprite Image { get; }
    void OnPickUp();
    void ToDrop();
}

public class InventoryEventArgs : EventArgs
{
    public InventoryEventArgs(ICollectable item)
    {
        Item = item;
    }

    public ICollectable Item;
}
