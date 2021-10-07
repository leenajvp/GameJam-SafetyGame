using UnityEngine;

public class HelmetSpot : MonoBehaviour, IPlayerDropSpot
{
    private MeshRenderer mesh;
    public bool isPlaced { get; set; }

    private void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        isPlaced = false;
    }

    private void Update()
    {
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
