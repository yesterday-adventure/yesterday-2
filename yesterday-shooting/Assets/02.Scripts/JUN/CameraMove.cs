using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public GameObject playerP;
    private bool move = true;
    void Update()
    {
        if(player.position.x - transform.position.x > offset.x && move)
        {
            StartCoroutine(CameraRight());
            move = false;
            //transform.DOMove(new Vector3(transform.position.x + offset.x * 2,transform.position.y,-10),0.1f,true);;
            //playerP.transform.position += new Vector3(1,0,0);
        }
        if(player.position.x - transform.position.x < -offset.x && move)
        {
            StartCoroutine(CameraLeft());
            move = false;
            //transform.DOMove(new Vector3(transform.position.x - offset.x * 2,transform.position.y,-10),0.1f,true);
            //playerP.transform.position += new Vector3(-1,0,0);
        }
        if(player.position.y - transform.position.y > offset.y && move)
        {
            StartCoroutine(CameraUp());
            move = false;
            //transform.DOMove(new Vector3(transform.position.x,transform.position.y + offset.y * 2,-10),0.1f,true);
            //playerP.transform.position += new Vector3(0,1,0);
        }
        if(player.position.y - transform.position.y < -offset.y && move)
        {
            StartCoroutine(CameraDown());
            move = false;
            //transform.DOMove(new Vector3(transform.position.x,transform.position.y - offset.y * 2,-10),0.1f,true);
            //playerP.transform.position += new Vector3(0,-1,0);
        }
    }

    IEnumerator CameraRight()
    {
        float x = transform.position.x;
        while(transform.position.x != x + offset.x * 2)
        {
            transform.position += new Vector3(1,0,0);
            yield return null;
        }
        playerP.transform.position += new Vector3(1,0,0);
        yield return new WaitForSeconds(0.1f);
        move = true;
    }

    IEnumerator CameraLeft()
    {
        float x = transform.position.x;
        while(transform.position.x != x - offset.x * 2)
        {
            transform.position += new Vector3(-1,0,0);
            yield return null;
        }
        playerP.transform.position += new Vector3(-1,0,0);
        yield return new WaitForSeconds(0.1f);
        move = true;
    }

    IEnumerator CameraUp()
    {
        float y = transform.position.y;
        while(transform.position.y != y + offset.y * 2)
        {
            transform.position += new Vector3(0,1,0);
            yield return null;
        }
        playerP.transform.position += new Vector3(0,1,0);
        yield return new WaitForSeconds(0.1f);
        move = true;
    }

    IEnumerator CameraDown()
    {
        float y = transform.position.y;
        while(transform.position.y != y - offset.y * 2)
        {
            transform.position += new Vector3(0,-1,0);
            yield return null;
        }
        playerP.transform.position += new Vector3(0,-1,0);
        yield return new WaitForSeconds(0.1f);
        move = true;
    }
}
