using UnityEngine;

public class TempMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 50f;
    public Inventory inventory;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0.0f, -rotationSpeed * Time.deltaTime, 0.0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
        }

        CollectItem();
    }

    public void CollectItem()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 0.5f);

        foreach (var col in colliders)
        {
            ICollectable collectableItem = col.GetComponent<ICollectable>();

            if (collectableItem != null)
            {
                inventory.AddItem(collectableItem);
            }
        }
    }
}
