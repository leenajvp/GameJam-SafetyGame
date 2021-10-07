using UnityEngine;

public class PlayerCollection : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 50f;
    public Inventory inventory;
    public bool helmetCollected;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    void Update()
    {
        CollectItem();
    }

    public void CollectItem()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);

        foreach (var col in colliders)
        {            
            ICollectable collectableItem = col.GetComponent<ICollectable>();

            if (collectableItem != null && collectableItem.isAvailable == true)
            {
                inventory.AddItem(collectableItem);
            }
        }
    }
}
