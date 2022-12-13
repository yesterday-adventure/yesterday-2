using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] float hp;
    [SerializeField] float speed;
    [SerializeField] float distance;


    Rigidbody rb;
    Animator _animator;
    GameObject player;

    private void Awake()
    {
        _animator = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
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
            if (distance >= 7)
            {
                //대기
                yield return new WaitForSeconds(0.1f);
            }
            else
            {
                if (distance < 2)
                {
                    //직접공격
                }
                else if (distance > 4)
                {
                    //소환
                }
                else
                {
                    while (distance > 4 || distance < 2)
                    {
                        rb.velocity = transform.position - player.transform.position;
                    }
                }
            }
        }
    }

}
