using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDamge : MonoBehaviour
{




    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            GameControlScript.health -= 1;
            Destroy(gameObject);


        }

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
