using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    void Update()
    {
        if(player.position.x - transform.position.x > offset.x)
        {
            transform.position = new Vector3(transform.position.x + offset.x * 2,transform.position.y,-10);
        }
        if(player.position.x - transform.position.x < -offset.x)
        {
            transform.position = new Vector3(transform.position.x - offset.x * 2,transform.position.y,-10);
        }
        if(player.position.y - transform.position.y > offset.y)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y + offset.y * 2,-10);
        }
        if(player.position.y - transform.position.y < -offset.y)
        {
            transform.position = new Vector3(transform.position.x,transform.position.y - offset.y * 2,-10);
        }
    }
}
