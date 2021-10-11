using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour, idamage
{
    private GameControlScript player;
    [SerializeField] int damage = 6;

    public void destroy()
    {
        
    }

    public int getdamage()
    {
        return damage;
    }
}
