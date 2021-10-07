using UnityEngine;

public class BucketSpot : MonoBehaviour, IPlayerDropSpot
{
    private SkinnedMeshRenderer mesh;
    public bool isPlaced { get; set; }

    private void Start()
    {
        mesh = GetComponent<SkinnedMeshRenderer>();
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
