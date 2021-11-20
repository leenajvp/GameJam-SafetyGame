using UnityEngine;

public class HatDropSpot : MonoBehaviour
{
    public enum HatType
    {
        Helmet,
        Bucket,
    }
    public HatType hatType;

    public bool isPlaced = false;

    public SkinnedMeshRenderer mesh;
    private GameObject player;
    public PlayerCollection playerScript;

    void Start()
    {
        gameObject.name = hatType.ToString();
        mesh = GetComponent<SkinnedMeshRenderer>();

        Transform holder = transform.parent;
        player = holder.transform.parent.gameObject;
        playerScript = player.GetComponent<PlayerCollection>();

    }

    private void Update()
    {
        if (playerScript.helmetCollected == false)
        {
            mesh.enabled = false;
            isPlaced = false;
        }
    }
}
