using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawner : MonoBehaviour
{

    [SerializeField]
    Image img;
    [SerializeField]
    Sprite sprite1;
    [SerializeField]
    Sprite sprite2;
    [SerializeField]
    Sprite sprite3;
    public List<GameObject> objectToSpawn = new List<GameObject>();


    public bool isRandomized;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnObject()
    {
        int index = isRandomized ? Random.Range(0, objectToSpawn.Count) : 0;

        if (objectToSpawn.Count > 0)
        {
            Instantiate(objectToSpawn[index], transform.position, Quaternion.identity); 
        }
        if (objectToSpawn[index].name == "hammer")
        {
            img.sprite = sprite1;
        }
        if (objectToSpawn[index].name == "piano")
        {
            img.sprite = sprite1;
        }
        if (objectToSpawn[index].name == "axe")
        {
            img.sprite = sprite1;
        }
    }

    
    
    






}
