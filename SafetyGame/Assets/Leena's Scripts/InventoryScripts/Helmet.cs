using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helmet : MonoBehaviour, ICollectable
{
    public bool isAvailable { get; set; }
    public Sprite image = null;

    private TempMovement player;

    public void Start()
    {
        isAvailable = true;
        player = FindObjectOfType<TempMovement>();
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
            var hitDropSpot = hit.collider.GetComponent<IPlayerDropSpot>();

            if (hitDropSpot != null)
            {
                GameObject selectedDropSpot;
                selectedDropSpot = hit.collider.gameObject;
                HelmetSpot helmetSpot = selectedDropSpot.GetComponent<HelmetSpot>();
                
                if (helmetSpot != null)
                {
                    helmetSpot.isPlaced = true;
                    player.helmetCollected = false;
                }
            }

            else
            {
                gameObject.SetActive(true);
                gameObject.transform.position = hit.point;

                isAvailable = true;
                player.helmetCollected = false;
            }
        }
    }
}
