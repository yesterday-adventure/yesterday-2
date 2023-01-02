using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_2Boss : MonoBehaviour
{
    Rigidbody2D _rigid = null;
    SpriteRenderer _spriteRenderer = null;
    GameObject _player = null; //플레이어 오브젝트

    [SerializeField] private Collider2D _wall;

    private bool playerOnR = false; //플래이어가 나보다 오른쪽에 있는지 확인

    [SerializeField] private bool farFromPlayer = false;
    private bool moveUp = false;

    [SerializeField] private float yDistance = 0; //플레이어와 나 사이의 y 거리
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
        playerOnR = transform.position.x < _player.transform.position.x;

        yDistance = Vector2.Distance(new Vector2(0, transform.position.y),
            new Vector2(0, _player.transform.position.y));

        _wall = Physics2D.OverlapBox(transform.position, new Vector2(2, 2), 0, 1 << 6);

        if (_wall != null)
        {
            moveUp = !moveUp;
        }


        if (farFromPlayer)
        {
            if (moveUp)
            {
                _rigid.velocity = new Vector2(0, 1) * 3;
            }
            else
            {
                _rigid.velocity = new Vector2(0, -1) * 3;
            }
        }
    }

    IEnumerator Pattern()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            _wall = null;
            yield return new WaitForSeconds(0.5f);

            if (yDistance <= 1.5f)
            {
                farFromPlayer = false;
                _rigid.velocity = Vector2.zero;
                if (playerOnR)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    _rigid.velocity = new Vector2(7, 0);
                    yield return new WaitUntil(() => _wall != null);
                    _rigid.velocity = Vector2.zero;
                    farFromPlayer = true;
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    _rigid.velocity = new Vector2(-7, 0);
                    yield return new WaitUntil(() => _wall != null);
                    _rigid.velocity = Vector2.zero;
                    farFromPlayer = true;
                }
            }
            else
            {
                farFromPlayer = true;
            }
        }
    }
}