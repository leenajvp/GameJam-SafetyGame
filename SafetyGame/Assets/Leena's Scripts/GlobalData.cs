using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GlobalData : MonoBehaviour
{
    [SerializeField] GameObject player;
    private GameControlScript healthScript;

    public Vector3 lastCheckPoint;
    [SerializeField] private GameObject startPosObj;

    private void Start()
    {
        healthScript = player.GetComponent<GameControlScript>();


        Time.timeScale = 1;

        if (PlayerPrefs.GetInt("SpawnPoint") == 0)
        {
           player.transform.position = startPosObj.transform.position;
        }

        if (PlayerPrefs.GetInt("SpawnPoint") == 1)
        {
           player.transform.position = lastCheckPoint;
        }
    }

    public void PlayerDead()
    {
       SceneManager.LoadScene("1");
    }
}