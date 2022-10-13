using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBulletMove : MonoBehaviour
{
    [SerializeField] float speed = 3f;
    private float time = 0f;
    private void OnEnable()
    {
        time = 0f;
    }
    void Update()
    {
        time += Time.deltaTime;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(time > 3)
        {
            PoolManager.Instance.Push(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Wall"))
        {
            PoolManager.Instance.Push(gameObject);
        }
    }
}
