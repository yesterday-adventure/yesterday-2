using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletMove : MonoBehaviour
{
    public float speed = 0f;
    private float time = 0f;
    private GameObject player = null;
    private Vector3 dir;

    private void Awake()
    {
        player = GameObject.Find("Player");
        dir = player.transform.position - transform.position;
    }

    private void OnEnable()
    {
        time = 0f;
        dir = player.transform.position - transform.position;
    }

    public void set(EnemyBulletDir.FireDir A)
    {
        if(A == EnemyBulletDir.FireDir.right)
            StartCoroutine(Right());
        else if(A == EnemyBulletDir.FireDir.left)
            StartCoroutine(Left());
        else if(A == EnemyBulletDir.FireDir.up)
            StartCoroutine(Up());
        else if(A == EnemyBulletDir.FireDir.down)
            StartCoroutine(Down());
        else if(A == EnemyBulletDir.FireDir.follow)
            StartCoroutine(Follow());
    }

    IEnumerator Right()
    {
        while(true)
        {
            Debug.Log("오른쪽");
            transform.position += speed * Time.deltaTime * Vector3.right;
            yield return null;
        }
    }

    IEnumerator Left()
    {
        while(true)
        {
            Debug.Log("왼쪽");
            transform.position += speed * Time.deltaTime * Vector3.left;
            yield return null;
        }
    }

    IEnumerator Up()
    {
        while(true)
        {
            Debug.Log("위쪽");
            transform.position += speed * Time.deltaTime * Vector3.up;
            yield return null;
        }
    }

    IEnumerator Down()
    {
        while(true)
        {
            Debug.Log("아래쪽");
            transform.position += speed * Time.deltaTime * Vector3.down;
            yield return null;
        }
    }

    IEnumerator Follow()
    {
        while(true)
        {
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