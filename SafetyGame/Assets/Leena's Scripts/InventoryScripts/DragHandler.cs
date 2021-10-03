using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IDragHandler, IEndDragHandler
{
    public ICollectable Item { get; set; }
    //private Renderer render;

    private void Start()
    {

    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        ChnageSpriteColor();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector3.zero;
    }

    private void ChnageSpriteColor()
    {
       // Image image = GetComponent<Image>();
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 50000))
        {
            var hitDropSpot = hit.collider.GetComponent<IDropSpot>();

            if (hitDropSpot != null)
            {
                
            }

            else
            {
                
            }
        }
    }
}
