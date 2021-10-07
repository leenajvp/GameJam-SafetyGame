using UnityEngine;

public class Helmet : Collectable
{
    public override bool isAvailable { get; set; }

    private TempMovement player;
    private HelmetSpot helmet;

    public override void Start()
    {
        isAvailable = true;
        player = FindObjectOfType<TempMovement>();
        helmet = FindObjectOfType<HelmetSpot>();
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
                    helmet.isPlaced = true;
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
