using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_2Boss : MonoBehaviour
{
    Rigidbody2D _rigid = null;
    SpriteRenderer _spriteRenderer = null;
    GameObject _player = null; //�÷��̾� ������Ʈ

    private bool playerOnR = false; //�÷��̾ ������ �����ʿ� �ִ��� Ȯ��
    private bool flip = false; //false �� ������ �ٶ�

    private bool farFromPlayer = false;
    private bool moveUp = false;

    [SerializeField] private float yDistance = 0; //�÷��̾�� �� ������ y �Ÿ�
    [SerializeField] private float hp = 0;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _player = PlayerManager.instance.player;
        StartCoroutine(this.Pattern());
    }

    private void Update()
    {
        _spriteRenderer.flipX = flip;

        playerOnR = transform.position.x < _player.transform.position.x;
        yDistance = Vector2.Distance(new Vector2(0, transform.position.y),
            new Vector2(0, _player.transform.position.y));

        if (farFromPlayer)
        {
            if (moveUp)
            {
                _rigid.velocity = new Vector2(0, 1);
            }
            else
            {
                _rigid.velocity = new Vector2(0, -1);
            }
        }
    }

    IEnumerator Pattern()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            if (yDistance <= 1.5f)
            {
                farFromPlayer = false;
                if (playerOnR)
                {
                    flip = false;
                }
                else
                {
                    flip = true;
                }
            }
            else
            {
                farFromPlayer = true;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Wall")
        {

        }
    }
}