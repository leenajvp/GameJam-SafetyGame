using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelmetSpot : MonoBehaviour, IPlayerDropSpot
{
    public bool isPlaced { get; set; }
    private MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
        isPlaced = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaced == true)
        {
            mesh.enabled = true;
        }
    }
}
