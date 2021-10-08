using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyObject : MonoBehaviour
{
    public GameObject gameobj;




    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameobj);
    }


    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        
    }
}
