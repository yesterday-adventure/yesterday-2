using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{
    public float speed = 0f;
    private float time = 0f;
    private GameObject player = null;
    private Vector3 dir;
    EnemyBulletDir enemyBulletDir;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void OnEnable()
    {
        time = 0f;
        dir = player.transform.position - transform.position;

        if(enemyBulletDir.fireDir == EnemyBulletDir.FireDir.right)
            StartCoroutine(Right());
        else if(enemyBulletDir.fireDir == EnemyBulletDir.FireDir.left)
            StartCoroutine(Left());
        else if(enemyBulletDir.fireDir == EnemyBulletDir.FireDir.up)
            StartCoroutine(Up());
        else if(enemyBulletDir.fireDir == EnemyBulletDir.FireDir.down)
            StartCoroutine(Down());
        else if(enemyBulletDir.fireDir == EnemyBulletDir.FireDir.follow)
            StartCoroutine(Follow());
    }

    IEnumerator Right()
    {
        while(true)
        {
            transform.position += speed * Time.deltaTime * Vector3.right;
            yield return new WaitForSeconds(0.1f);
        }
    }

    IEnumerator Left()
    {
        while(true)
        {
            transform.position += speed * Time.deltaTime * Vector3.left;
            yield return null;
        }
    }

    IEnumerator Up()
    {
        while(true)
        {
            transform.position += speed * Time.deltaTime * Vector3.up;
            yield return null;
        }
    }

    IEnumerator Down()
    {
        while(true)
        {
            transform.position += speed * Time.deltaTime * Vector3.down;
            yield return null;
        }
    }

    IEnumerator Follow()
    {
        while(true)
        {
            Debug.Log("123");
            transform.position += speed * Time.deltaTime * dir.normalized;
            yield return null;
        }
    }
    void Update()
    {
        time += Time.deltaTime;
        
        if(time > 1.5)
        {
            StopAllCoroutines();
            PoolManager.Instance.Push(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Wall"))
        {
            StopAllCoroutines();
            PoolManager.Instance.Push(gameObject);
        }
    }
}