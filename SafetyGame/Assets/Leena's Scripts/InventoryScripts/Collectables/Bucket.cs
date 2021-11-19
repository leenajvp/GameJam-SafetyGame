using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : CollectableBase
{
    [SerializeField]
    private PlayerCollection playerChar;
    [SerializeField]
    private BucketSpot bucketOnPlayer;

    public override void Start()
    {
        base.Start();
        isAvailable = true;

        if (playerChar == null)
        {
            try { playerChar = FindObjectOfType<PlayerCollection>(); }
            catch { Debug.LogError("Player is null"); }
        }

        if (bucketOnPlayer == null)
        {
            try { bucketOnPlayer = FindObjectOfType<BucketSpot>(); }
            catch { Debug.LogError("Bucket on player is null"); }
        }
    }

    public override void Drop()
    {
        base.Drop();

        RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 50000))
        {
            var hitDropSpot = hit.collider.GetComponent<IPlayerDropSpot>();

            if (playerChar.helmetCollected == false)
            {
                if (hitDropSpot != null && playerChar.helmetCollected == false)
                {
                    playerChar.helmetCollected = true;
                    bucketOnPlayer.isPlaced = true;
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
