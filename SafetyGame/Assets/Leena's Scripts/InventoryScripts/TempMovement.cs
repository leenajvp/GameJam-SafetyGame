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

    public void Update()
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

        Collect();
    }

    public void Collect()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1f);

        foreach (var col in colliders)
        {
            ICollectable pickableObject = col.GetComponent<ICollectable>();

            if (pickableObject != null)
            {
                inventory.AddItem(pickableObject);
            }
        }
    }

}
