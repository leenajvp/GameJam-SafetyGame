using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Respawn : MonoBehaviour
{
    
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnpoint;
    private Spawner[] spawner;



    private void Start()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
            player.transform.position = respawnpoint.transform.position;
        
        

        
       
    }

    private void ResetGame()
    {
        // Triggers to set false
        //collectables
        //pushObjects reset
        
        
    }



   
       






}
