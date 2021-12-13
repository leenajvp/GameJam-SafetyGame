using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint: MonoBehaviour
{
    [SerializeField] int checkPointNumber;
    [SerializeField] private GameObject startPosObj;
    private GameObject player;

    void Start()
    {
        Time.timeScale = 1;
        startPosObj = GameObject.Find("StartPos");
        player = FindObjectOfType<move>().gameObject;

        if (PlayerPrefs.GetInt("SpawnPoint") == 0)
        {
            //player.transform.position = startPosObj.transform.position;
        }

        if (PlayerPrefs.GetInt("SpawnPoint") == checkPointNumber)
        {
            //LastCheckPoint();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerPrefs.SetInt("SpawnPoint", checkPointNumber);
        }
    }

    public void LastCheckPoint()
    {
        player.transform.position = transform.position;
    }
}

