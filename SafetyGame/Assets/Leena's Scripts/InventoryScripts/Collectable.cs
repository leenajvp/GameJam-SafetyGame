using UnityEngine;
using UnityEngine.UI;

public class Collectable : MonoBehaviour, ICollectable
{
    public bool isAvailable { get; set; }
    public Sprite image = null;

    public void Start()
    {
        isAvailable = true;
    }

    public Sprite Image
    {
        get
        {
            return image;
        }
    }

    public void Collect()
    {
        gameObject.SetActive(false);
    }

    public void Drop()
    {

        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000))
        {
            gameObject.SetActive(true);
            gameObject.transform.position = hit.point;

            isAvailable = false;

            var hitDropSpot = hit.collider.GetComponent<IDropSpot>();

            if (hitDropSpot != null)
            {
                GameObject selectedDropSpot;
                selectedDropSpot = hit.collider.gameObject;
                gameObject.SetActive(true);
                gameObject.transform.position = selectedDropSpot.transform.position;

                isAvailable = false;
            }
        }
    }

    //public void Drop()
    //{

    //}
}

