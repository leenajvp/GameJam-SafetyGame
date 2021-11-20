using UnityEngine;
using UnityEngine.EventSystems;

public class DropHandler : MonoBehaviour, IDropHandler
{
    private Inventory inventory;

    private void Awake()
    {
        if (inventory == null)
        {
            try { inventory = FindObjectOfType<Inventory>(); }
            catch { Debug.LogError("Inventory script in drophandler cannot be null"); }
        }
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
