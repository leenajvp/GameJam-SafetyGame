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

        }

    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "object")
        {
            healthh -= damage;
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag == "health")
        {
            healthh += damage;
        }
        else
        {
            if (other.transform.tag == "floor")
            {
                healthh -= damage;
            }
        }


    }
     
    




}

