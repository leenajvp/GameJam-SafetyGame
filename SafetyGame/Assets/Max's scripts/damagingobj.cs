using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damagingobj : MonoBehaviour, idamage
{
    [SerializeField]
    int dam = 2;
    public int getdamage()
    {
        return  dam;
    }
    public void destroy()
    {
        gameObject.SetActive(false);
    }
    public void Update()
    {

    }
}
