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

    public void Update()
    {

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
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        idamage fallobj = collision.collider.GetComponent<idamage>();
        if (fallobj != null)
        {
            int damage = fallobj.getdamage();
            fallobj.destroy();
            // if (bool helmeton = true)
            // (health(0);
            //else
            // health(damage)
            health(damage);
        }
    }
}

