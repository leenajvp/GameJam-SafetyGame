using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : CollectableBase
{
    public override void Drop()
    {
        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000))
        {
            var hitDropSpot = hit.collider.GetComponent<LadderDrop>();

            if (hitDropSpot!=null)
            {
                LadderDrop ladderSpot = hitDropSpot.gameObject.GetComponent<LadderDrop>();
                GameObject placeLadder = ladderSpot.ladder;
                placeLadder.SetActive(true);
                Destroy(gameObject);
            }

            else
            {
                gameObject.SetActive(true);
                gameObject.transform.position = hit.point;
                isAvailable = false;
            }
        }
    }
}
