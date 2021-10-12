using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControlScript : MonoBehaviour
{ 
    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyheart;

    int maxhealth = 6;
    int minhealth = 0;
    int starthealth = 6;

    [SerializeField] GameObject helmet;
    private PlayerCollection player;
    private MenuScript gd;

    public void Start()
    {
        player = GetComponent<PlayerCollection>();
        gd = FindObjectOfType<MenuScript>();
        
    }

    private void Update()
    {
        if (starthealth == 0)
        {
            gd.PlayerDead();
        }
    }

    public void health(int x)
    {
        starthealth = starthealth + x;
        if (starthealth < minhealth)
            starthealth = minhealth;
        if (starthealth > maxhealth)
            starthealth = maxhealth;
        Debug.Log(starthealth);
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i + 1 <= starthealth)
            {
                hearts[i].sprite = fullheart;
            }
            else
                hearts[i].sprite = emptyheart;


            if (starthealth <= 0)
            {
                Time.timeScale = 0f;
            }
        }

       
    }
    public void OnCollisionEnter(Collision collision)
    {
        idamage fallobj = collision.collider.GetComponent<idamage>();

        if (fallobj != null)
        {
            GameObject hitObject = collision.gameObject;
            int damage = fallobj.getdamage();
            hitObject.transform.position = hitObject.transform.position + transform.right * 4;

            if (player.helmetCollected == true)
            {
                health(0);
                player.helmetCollected = false;
            }

            else
            {
                health(damage);
                player.helmetCollected = false;
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        idamage fallTrigger = other.GetComponent<idamage>();
        //int damage = fallTrigger.getdamage();

        if (fallTrigger != null)
        {
            int damage = fallTrigger.getdamage();
            health(damage);
        }
    }
}

