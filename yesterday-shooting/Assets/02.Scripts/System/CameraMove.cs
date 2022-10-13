using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMove : MonoBehaviour
{
    [SerializeField] DoorOnOff doorOnOff;

    public Transform player;
    public Vector3 offset;

    public GameObject playerP;
    private bool move = true;

    private void Awake()
    {
        if(doorOnOff == null)
        {
            doorOnOff = GetComponent<DoorOnOff>();
        }    
    }

    void Update()
    {
        if (player.position.x - transform.position.x > offset.x && move)
        {
            StartCoroutine(CameraRight());
            doorOnOff.dir = Dir.right;
            doorOnOff.changePos();
            move = false;
        }
        if (player.position.x - transform.position.x < -offset.x && move)
        {
            StartCoroutine(CameraLeft());
            doorOnOff.dir = Dir.left;
            doorOnOff.changePos();
            move = false;
        }
        if (player.position.y - transform.position.y > offset.y && move)
        {
            StartCoroutine(CameraUp());
            doorOnOff.dir = Dir.up;
            doorOnOff.changePos();
            move = false;
        }
        if (player.position.y - transform.position.y < -offset.y && move)
        {
            StartCoroutine(CameraDown());
            doorOnOff.dir = Dir.down;
            doorOnOff.changePos();
            move = false;
        }

    }

    IEnumerator CameraRight()
    {
        float x = transform.position.x;
        while (transform.position.x != x + offset.x * 2)
        {
            transform.position += new Vector3(1, 0, 0);
            yield return null;
        }
        playerP.transform.position += new Vector3(1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        move = true;
    }

    IEnumerator CameraLeft()
    {
        float x = transform.position.x;
        while (transform.position.x != x - offset.x * 2)
        {
            transform.position += new Vector3(-1, 0, 0);
            yield return null;
        }
        playerP.transform.position += new Vector3(-1, 0, 0);
        yield return new WaitForSeconds(0.1f);
        move = true;
    }

    IEnumerator CameraUp()
    {
        float y = transform.position.y;
        while (transform.position.y != y + offset.y * 2)
        {
            transform.position += new Vector3(0, 1, 0);
            yield return null;
        }
        playerP.transform.position += new Vector3(0, 1, 0);
        yield return new WaitForSeconds(0.1f);
        move = true;
    }

    IEnumerator CameraDown()
    {
        float y = transform.position.y;
        while (transform.position.y != y - offset.y * 2)
        {
            transform.position += new Vector3(0, -1, 0);
            yield return null;
        }
        playerP.transform.position += new Vector3(0, -1, 0);
        yield return new WaitForSeconds(0.1f);
        move = true;
    }
}