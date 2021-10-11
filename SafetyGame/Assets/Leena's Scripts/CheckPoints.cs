using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoints : MonoBehaviour
{
    GlobalData gd;
    Transform lastCheckPoint;
    
    void Start()
    {
        gd = GameObject.Find("GameManager").GetComponent<GlobalData>();
        gd = FindObjectOfType<GlobalData>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gd.lastCheckPoint = transform.position;
            PlayerPrefs.SetInt("SpawnPoint", 1);
        }
    }
}

