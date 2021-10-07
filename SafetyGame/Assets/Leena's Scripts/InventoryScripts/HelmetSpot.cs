using UnityEngine;

public class HelmetSpot : MonoBehaviour, IPlayerDropSpot
{
    private SkinnedMeshRenderer mesh;
    private PlayerCollection player;
    public bool isPlaced { get; set; }

    private void Start()
    {
        player = transform.parent.GetComponent<PlayerCollection>();
        mesh = GetComponent<SkinnedMeshRenderer>();
        isPlaced = false;
    }

    private void Update()
    {
        if (player.helmetCollected == false)
        {
            isPlaced = false;
        }

        if (isPlaced == true)
        {
            mesh.enabled = true;
        }

        else
        {
            mesh.enabled = false;
        }
    }
}
