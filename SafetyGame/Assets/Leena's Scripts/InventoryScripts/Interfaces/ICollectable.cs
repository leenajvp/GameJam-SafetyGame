﻿using System;
using UnityEngine;

public interface ICollectable
{
    Sprite Image { get; }
    bool isAvailable { get; set; }
    void Collect();
    void Drop();
}

public class InventoryEventArgs : EventArgs
{
    public ICollectable Item;

    public InventoryEventArgs(ICollectable collectedItem)
    {
        Item = collectedItem;
    }
}
