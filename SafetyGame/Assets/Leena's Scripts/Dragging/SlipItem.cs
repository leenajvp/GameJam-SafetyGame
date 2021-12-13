using UnityEngine;

public class SlipItem : DragItem, idamage
{
    [SerializeField]
    int damage = -3;

    public int getdamage()
    {
        return damage;
    }

    public void destroy()
    {
        //nope
    }
}

