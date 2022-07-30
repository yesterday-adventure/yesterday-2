using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    [Tooltip("�̵��ӵ�")]
    [SerializeField] float speed = 5f;
    [Tooltip("���� ����")]
    [SerializeField] float range = 0;

    
    private GameObject player = null;
    [SerializeField] Rigidbody2D rigid = null;

    private void OnEnable()
    {
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
    }
}
