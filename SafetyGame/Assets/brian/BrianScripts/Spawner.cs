using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawner : MonoBehaviour
{

    [SerializeField]
    Image img;
    [SerializeField]
    Sprite piano;
    [SerializeField]
    Sprite hammer;
    [SerializeField]
    Sprite axe;
    public List<GameObject> objectToSpawn = new List<GameObject>();
    public bool spawned = false;

    public bool isRandomized;
    // Start is called before the first frame update
    void Start()
    {
        img.enabled = false;
        spawned = false;
    }
    // Update is called once per frame
    void Update()
    {

    }
    public void SpawnObject()
    {
        int index = isRandomized ? Random.Range(0, objectToSpawn.Count) : 0;

        if (objectToSpawn.Count > 0 && spawned == false)
        {
            Instantiate(objectToSpawn[index], transform.position, Quaternion.identity);
            spawned = true;
        }
        if (objectToSpawn[index].name == "hammer")
        {
            img.sprite = hammer;
        }
        if (objectToSpawn[index].name == "piano")
        {
            img.sprite = piano;
        }
        if (objectToSpawn[index].name == "axe")
        {
            img.sprite = axe;
        }
        img.enabled = true;
        StartCoroutine(TurnOffImage());
    }

    private IEnumerator TurnOffImage()
    {
        yield return new WaitForSeconds(2);

        img.enabled = false;
    }
}
