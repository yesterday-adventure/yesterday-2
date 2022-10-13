using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [Tooltip("이동속도")]
    [SerializeField] float speed = 5f;
    [Tooltip("감지 범위")]
    [SerializeField] float range = 0;

    SpriteRenderer _spriteRenderer = null;
    private GameObject player = null;
    [SerializeField] Rigidbody2D rigid = null;

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        Vector2 degree = player.transform.position - transform.position;
        if (degree.magnitude <= range)
        {
            rigid.velocity = degree.normalized * speed;
        }
        else
        {
            rigid.velocity = Vector2.zero;
        }
        if(degree.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }
}
