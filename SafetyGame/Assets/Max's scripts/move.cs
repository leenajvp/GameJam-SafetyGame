using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField]
    float topspeed = 5.0f;
    [SerializeField]
    float charspeed = 5.0f;
    [SerializeField]
    float acceleration = 2.0f;
    float speed;
    [SerializeField]
    float rotspeed = 60.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * charspeed * Time.deltaTime;
        Collider[] colliders = Physics.OverlapSphere(transform.position, 1.001f);
        int num = 0;
        foreach (var i in colliders)
        {
            if (i.name == "walk plane")
                num += 1;
            if (i.name == "Wood")
                num += 1;
        }
        if (num == 0)
        {
            speed += acceleration * Time.deltaTime;
            if (speed > topspeed)
            {
                speed = topspeed;
            }
            transform.position = transform.position + -transform.up * speed * Time.deltaTime;
        }
        else
        {
            foreach (var col in colliders)
            {
                if (col.name == "walk plane")
                {
                    if (transform.rotation.eulerAngles.y != col.transform.rotation.eulerAngles.y)
                    {
                        if (col.transform.rotation.eulerAngles.y + 1 < transform.rotation.eulerAngles.y)
                        {
                            rotspeed = -60;
                        }
                        if (col.transform.rotation.eulerAngles.y == 270 && transform.rotation.eulerAngles.y == 0)
                            rotspeed = -60;
                        if (col.transform.rotation.eulerAngles.y == 90 && transform.rotation.eulerAngles.y == 0)
                            rotspeed = 60;
                        if (col.transform.rotation.eulerAngles.y == 0 && transform.rotation.eulerAngles.y <= 90)
                            rotspeed = -60;
                        if (col.transform.rotation.eulerAngles.y == 0 && transform.rotation.eulerAngles.y >= 270)
                            rotspeed = 60;
                        transform.Rotate(0, rotspeed * Time.deltaTime, 0);
                        Debug.Log(rotspeed);
                        if (rotspeed > 0)
                        {
                            Debug.Log("right");
                            if (col.transform.rotation.eulerAngles.y == 0)
                            {
                                if (transform.rotation.eulerAngles.y < 30)
                                    transform.Rotate(0, (col.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y), 0);

                            }
                            else
                            {
                                if (transform.rotation.eulerAngles.y > col.transform.rotation.eulerAngles.y)
                                {
                                    transform.Rotate(0, (col.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y), 0);
                                }
                            }
                        }
                        else
                        {
                            Debug.Log("left");
                            if (col.transform.rotation.eulerAngles.y == 0)
                            {
                                if (transform.rotation.eulerAngles.y > 300)
                                    transform.Rotate(0, (col.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y), 0);
                            }
                            if (transform.rotation.eulerAngles.y < col.transform.rotation.eulerAngles.y)
                            {
                                transform.Rotate(0, (col.transform.rotation.eulerAngles.y - transform.rotation.eulerAngles.y), 0);
                            }
                        }
                    }
                    if (transform.rotation.eulerAngles.x != col.transform.rotation.eulerAngles.x)
                    {
                        transform.Rotate((col.transform.rotation.eulerAngles.x - transform.rotation.eulerAngles.x), 0, 0);
                    }

                    if (transform.rotation.eulerAngles.y == col.transform.rotation.eulerAngles.y)
                    {
                        if (transform.rotation.eulerAngles.y == 90)
                        {
                            float km = col.transform.position.z - transform.position.z;
                            if (km != 0)
                                transform.position = transform.position - transform.right * km * Time.deltaTime;
                        }
                        else
                        {
                            if (transform.rotation.eulerAngles.y == 270)
                            {
                                float km = col.transform.position.z - transform.position.z;
                                if (km != 0)
                                    transform.position = transform.position + transform.right * km * Time.deltaTime;
                            }
                            else
                            {
                                if (transform.rotation.eulerAngles.y == 180)
                                {
                                    float km = col.transform.position.x - transform.position.x;
                                    if (km != 0)
                                        transform.position = transform.position - transform.right * km * Time.deltaTime;
                                }
                                else
                                {
                                    float km = col.transform.position.x - transform.position.x;
                                    if (km != 0)
                                        transform.position = transform.position + transform.right * km * Time.deltaTime;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
