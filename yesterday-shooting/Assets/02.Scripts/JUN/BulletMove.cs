using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float fireSpeed = 0;
    private Vector3 dir = new Vector3(0,0,0);
    private float time = 0;

    private bool checkdir = false;
    PlayerFire playerFire;
    private void Awake()
    {
        playerFire = GameObject.Find("Player").GetComponent<PlayerFire>();
    }
    private void OnEnable()
    {
        checkdir = false;
        time = 0;
        fireSpeed = 5f;
        
    }

    private void Update()
    {
        if(checkdir == false)
        {
            if((short)playerFire.fireDir == 0)
                dir = new Vector3(1,0,0);
            else if((short)playerFire.fireDir == 1)
                dir = new Vector3(-1,0,0);
            else if((short)playerFire.fireDir == 2)
                dir = new Vector3(0,-1,0);
            else if((short)playerFire.fireDir == 3)
                dir = new Vector3(0,1,0);

            checkdir = true;
        }
        transform.position += fireSpeed * Time.deltaTime * dir;

        time += Time.deltaTime;
        
        if(time > 1.5f)
        {
            PoolManager.Instance.Push(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
