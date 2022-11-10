using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float fireSpeed = 0;
    private Vector3 dir = new Vector3(0, 0, 0);
    private float time = 0;

    [SerializeField] private float lifeTime = 0f;
    private bool checkdir = false;
    PlayerFire playerFire;

    private void Awake()
    {
        playerFire = GameObject.Find("Player").GetComponent<PlayerFire>();
    }
    private void OnEnable()
    {
        checkdir = false;
        time = 0f;
    }

    private void Update()
    {
        if (checkdir == false)
        {
            if ((short)playerFire.fireDir == 0)
                dir = new Vector3(1, 0, 0);
            else if ((short)playerFire.fireDir == 1)
                dir = new Vector3(-1, 0, 0);
            else if ((short)playerFire.fireDir == 2)
                dir = new Vector3(0, -1, 0);
            else if ((short)playerFire.fireDir == 3)
                dir = new Vector3(0, 1, 0);

            checkdir = true;
        }
        transform.position += fireSpeed * Time.deltaTime * dir.normalized;

        time += Time.deltaTime;

        if (time > lifeTime)
        {
            PoolManager.Instance.Push(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Wall"))
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
