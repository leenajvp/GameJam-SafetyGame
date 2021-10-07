﻿using UnityEngine;

public class TempMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 50f;
    public Inventory inventory;
    public bool helmetCollected;

    private void Awake()
    {
        inventory = FindObjectOfType<Inventory>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }

        //if (Input.GetKey(KeyCode.A))
        //{
        //    transform.Rotate(0.0f, -rotationSpeed * Time.deltaTime, 0.0f);
        //}

        //if (Input.GetKey(KeyCode.D))
        //{
        //    transform.Rotate(0.0f, rotationSpeed * Time.deltaTime, 0.0f);
        //}

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
                GameObject collectedItem = col.gameObject;
                Helmet helmet = collectedItem.GetComponent<Helmet>();

                if (helmet != null)
                {
                    helmetCollected = true;
                }

                else
                {
                    return;
                }
            }
        }
    }
}