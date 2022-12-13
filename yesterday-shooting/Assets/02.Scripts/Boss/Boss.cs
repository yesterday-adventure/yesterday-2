using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject hand;

    [SerializeField] float hp;
    [SerializeField] float speed;
    [SerializeField] float distance;
    [SerializeField] float summonRange;

    Rigidbody2D rb;
    Animator _animator;
    GameObject player;


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
    }

    private IEnumerator Pattern()
    {
        while (hp > 0)
        {
            yield return new WaitForSeconds(3);
            if (distance >= 7)
            {
                //대기
                rb.velocity = Vector2.zero;
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                if (distance < 2)
                {
                    //직접공격
                    rb.velocity = Vector2.zero;
                    Attack();
                    yield return new WaitForSeconds(0.1f);
                }
                else if (distance > 4)
                {
                    //소환
                    rb.velocity = Vector2.zero;
                    for (int i = 0; i < 4; i++)
                    {
                        Summon(i);
                        yield return new WaitForSeconds(i / 2);
                    }
                }
                else
                {
                    //걷기
                    rb.velocity = (player.transform.position - transform.position).normalized * speed;
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }
    }

    private void Summon(int loop = 1)
    {
        for (int i = 0; i < loop; i++)
        {
            Instantiate(hand, SetPos(), Quaternion.identity);
        }
    }

    private Vector2 SetPos()
    {
        return (Vector2)player.transform.position + UnityEngine.Random.insideUnitCircle * summonRange;
    }

    private void Attack()
    {

    }
}
