using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject hand;

    [SerializeField] float hp;
    [SerializeField] float speed;
    [Tooltip("�÷��̾�� ������ �Ŷ�")]
    [SerializeField] float distance = 10;
    [Tooltip("�÷��̾� ��ó �� ��ȯ ����")]
    [SerializeField] float summonRange;

    Rigidbody2D rb;
    Animator _animator;
    GameObject player;

    private bool walkState = false;

    private void Awake()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        player = FindObjectOfType<PlayerHp>().transform.gameObject;
        StartCoroutine(Pattern());
    }

    private void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);

        if (walkState)
        {
            rb.velocity = (player.transform.position - transform.position).normalized * speed;
            _animator.SetBool("Walk", true);
            Debug.Log("�ȱ�");
        }
        else
        {
            rb.velocity = Vector2.zero;
            _animator.SetBool("Walk", false);
            Debug.Log("���߱�");
        }

        if (player.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector2(-1, 1);
        }
        else
        {
            transform.localScale = new Vector2(1, 1);
        }
    }

    private IEnumerator Pattern()
    {
        while (hp > 0)
        {
            if (distance < 2)
            {
                //��������
                walkState = false;
                Attack();
                yield return new WaitForSeconds(3f);
            } //����
            else if (distance > 6)
            {
                //��ȯ
                walkState = false;
                _animator.SetBool("Summon", true);
                yield return new WaitForSeconds(0.08f);
                _animator.SetBool("Summon", false);
                for (int i = 1; i <= 3; i++)
                {
                    Summon();
                    yield return new WaitForSeconds(1);
                }
            } //��ȯ
            else
            {
                walkState = true;
                yield return new WaitUntil(() => distance > 4 || distance < 2);
            } //�ȱ�
            yield return new WaitForSeconds(1);
        }
    }

    private void Summon()
    {
        Instantiate(hand, SetPos(), Quaternion.identity);
    }

    private Vector2 SetPos()
    {
        return (Vector2)player.transform.position + UnityEngine.Random.insideUnitCircle * summonRange;
    }

    private void Attack()
    {
        _animator.SetBool("Attack", true);
        Debug.Log("����");
    }
}
