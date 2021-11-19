using UnityEngine;

public class Helmet : CollectableBase
{
    [SerializeField]
    private PlayerCollection playerChar = null;
    [SerializeField]
    private HelmetSpot helmetOnPlayer = null;

    public override void Start()
    {
        if (playerChar == null)
        {
            try { playerChar = FindObjectOfType<PlayerCollection>(); }
            catch { Debug.LogError("Player is null"); }
        }

        if (helmetOnPlayer == null)
        {
            try { helmetOnPlayer = FindObjectOfType<HelmetSpot>(); }
            catch { Debug.LogError("Helmet on player is null"); }
        }

        base.Start();
        isAvailable = true;
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
                    helmetOnPlayer.isPlaced = true;
                    playerChar.helmetCollected = true;
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
