using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : Collectable
{
    public override bool isAvailable { get; set; }

    private TempMovement player;
    private BucketSpot bucket;

    public override void Start()
    {
        isAvailable = true;
        player = FindObjectOfType<TempMovement>();
        bucket = FindObjectOfType<BucketSpot>();
    }

    public override void Drop()
    {
        base.Drop();

        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000))
        {
            var hitDropSpot = hit.collider.GetComponent<IPlayerDropSpot>();

            if (player.helmetCollected == false)
            {
                if (hitDropSpot != null && hitDropSpot.isPlaced == false)
                {
                    bucket.isPlaced = true;
                    Destroy(gameObject);
                }

                else
                {
                    return;
                }
            }
        }
    }
}
