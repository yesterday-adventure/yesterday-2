using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : GameManager
{
    [Tooltip("�̵��ӵ�")]
    [SerializeField] float speed = 5f;
    [Tooltip("���� ����")]
    [SerializeField] float range = 0;

    SpriteRenderer _spriteRenderer = null;
    private GameObject player = null;
    [SerializeField] Rigidbody2D rigid = null;

    NavMeshAgent2D agent;
    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        // Vector2 degree = player.transform.position - transform.position;
        // if (degree.magnitude <= range)
        // {
        //     rigid.velocity = degree.normalized * speed;
        // }
        // else
        // {
        //     rigid.velocity = Vector2.zero;
        // }
        // if(degree.x > 0)
        // {
        //     _spriteRenderer.flipX = false;
        // }
        // else
        // {
        //     _spriteRenderer.flipX = true;
        // }
        startPos = new Vector2Int((int)transform.position.x,(int)transform.position.y);
        targetPos = new Vector2Int((int)player.transform.position.x,(int)player.transform.position.y);
        PathFinding();
    }
}
