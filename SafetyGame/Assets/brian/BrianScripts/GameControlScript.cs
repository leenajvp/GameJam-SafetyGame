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
        if (collision.collider.tag == "object")
        {
            Damagingitem dItem = collision.gameObject.GetComponent<Damagingitem>();
            

            healthh -= dItem.damage;
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


}

