﻿using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    private Inventory inventory;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        RectTransform invPanel = transform as RectTransform;

        if (!RectTransformUtility.RectangleContainsScreenPoint(invPanel, Input.mousePosition))
        {
            ICollectable item = eventData.pointerDrag.gameObject.GetComponent<DragHandler>().Item;
            if (item != null)
            {
                inventory.RemoveItem(item);
                item.Drop();
            }
        }
    }
}
