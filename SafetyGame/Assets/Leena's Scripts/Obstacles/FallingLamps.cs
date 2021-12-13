using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingLamps : MonoBehaviour
{
    [SerializeField]
    Image lampImg;
    [SerializeField]
    GameObject lampToDrop;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lampImg.enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            lampToDrop.GetComponent<Rigidbody>().useGravity = true;
            lampImg.enabled=false;
        }
    }
}
