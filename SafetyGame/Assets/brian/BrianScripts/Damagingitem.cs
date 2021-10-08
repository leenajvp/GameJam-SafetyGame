using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damagingitem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<GameControlScript>().getDamge();
        
    }
}
