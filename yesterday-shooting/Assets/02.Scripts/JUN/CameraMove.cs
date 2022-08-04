using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public GameObject playerP;
    
    void Update()
    {
        if(player.position.x - transform.position.x > offset.x)
        {
            playerP.transform.position += new Vector3(1,0,0);
            transform.DOMove(new Vector3(transform.position.x + offset.x * 2,transform.position.y,-10),0.1f);
        }
        if(player.position.x - transform.position.x < -offset.x)
        {
            playerP.transform.position += new Vector3(-1,0,0);
            transform.DOMove(new Vector3(transform.position.x - offset.x * 2,transform.position.y,-10),0.1f);
        }
        if(player.position.y - transform.position.y > offset.y)
        {
            playerP.transform.position += new Vector3(0,1,0);
            transform.DOMove(new Vector3(transform.position.x,transform.position.y + offset.y * 2,-10),0.1f);
        }
        if(player.position.y - transform.position.y < -offset.y)
        {
            playerP.transform.position += new Vector3(0,-1,0);
            transform.DOMove(new Vector3(transform.position.x,transform.position.y - offset.y * 2,-10),0.1f);
        }
    }
}
