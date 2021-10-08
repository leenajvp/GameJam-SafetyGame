using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour
{

    public int healthh;
    public int numOfHearts;
    [SerializeField] int damage;
    

   
    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyheart;


    

     

    public void Update()
    {

        if (healthh > numOfHearts)
        {
            healthh = numOfHearts;

        }



         for (int i = 0; i < hearts.Length; i++)
        {
            if(i < healthh)
            {
                hearts[i].sprite = fullheart;

            }
            else
            {
                hearts[i].sprite = emptyheart;
            }


            if (i < numOfHearts)
            {
                hearts[i].enabled = true;

            }
            else
            {
                hearts[i].enabled = false;
               
            }

            if (healthh == 0)
            {
                Time.timeScale = 0;
            }

        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        // DamagagingObject fallingItem = collision.collider.gameobject.GetComponent<DamagingObject>().
        // if (fallingItem)
        //  damange = fallingitem.damage;
        

        if (collision.collider.tag == "object")
        {
            healthh -= 1;

           
            


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "health")
        {
            healthh += 1;
        }
        else
        {
            if (other.transform.tag == "floor")
            {
                healthh -= 1;
            }
        }


    }

    public void getDamge() 
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 2f);

        foreach (var col in colliders)
        {
            Damagingitem dltem = col.GetComponent<Damagingitem>();

            if (dltem != null)
            {
                healthh -= damage;
            }
        }

    }
    
     
    




}

