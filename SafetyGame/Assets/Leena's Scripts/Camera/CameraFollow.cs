using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float yMax = 2;
    [SerializeField] private float yMin = -2;

    [SerializeField] private float xOffset = 4;
    [SerializeField] private float yOffset = 2;

    void FixedUpdate()
    {
        Vector3 offset = transform.position - player.transform.position;
        Vector3 cameraPos = transform.position;
        cameraPos.x = (player.transform.position.x + xOffset);

        bool moveY = false;

        if (offset.y > yMax)
        {
            moveY = true;
            cameraPos.y = (player.transform.position.y + offset.y) - (offset.y - yOffset);
        }
        else if (offset.y < yMin)
        {
            moveY = true;
            cameraPos.y = (player.transform.position.y + offset.y) - (offset.y + yOffset);
        }

        if (!moveY)
        {
            cameraPos.y = transform.position.y;
        }

        transform.position = cameraPos;
    }
}
