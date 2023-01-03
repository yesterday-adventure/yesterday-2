using System.Collections;
using UnityEngine;

public class Stage1_2Boss : MonoBehaviour
{
    Rigidbody2D _rigid = null;
    GameObject _player = null; //�÷��̾� ������Ʈ
    Animator _anim = null;

    [SerializeField] private Collider2D yWall;
    [SerializeField] private Collider2D xWall;

    private bool playerOnR = false; //�÷��̾ ������ �����ʿ� �ִ��� Ȯ��

    [SerializeField] private bool farFromPlayer = false;
    private bool moveUp = false;

    [SerializeField] private float yDistance = 0; //�÷��̾�� �� ������ y �Ÿ�
    [SerializeField] private float hp = 0;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    private void Start()
    {
        _player = PlayerManager.instance.player;
        StartCoroutine(this.Pattern());
    }

    private void Update()
    {
        playerOnR = transform.position.x < _player.transform.position.x;

        yWall = Physics2D.OverlapBox(transform.position, new Vector2(1, 2.5f), 0, 1 << 6);
        xWall = Physics2D.OverlapBox(transform.position, new Vector2(2.5f, 1), 0, 1 << 6);

        if (yWall != null)
        {
            moveUp = !moveUp;
        }


        if (farFromPlayer)
        {
            _anim.SetBool("IsRun", false);
            if (moveUp)
            {
                _rigid.velocity = new Vector2(0, 1) * 3;
            }
            else
            {
                _rigid.velocity = new Vector2(0, -1) * 3;
            }
        }

        if (hp <= 0)
        {
            _anim.SetTrigger("Die");
        }
    }

    IEnumerator Pattern()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            yWall = null;
            xWall = null;
            yield return new WaitForSeconds(0.1f);

            yDistance = Vector2.Distance(new Vector2(0, transform.position.y),
                new Vector2(0, _player.transform.position.y));

            if (yDistance <= 1.5f)
            {
                farFromPlayer = false;
                _rigid.velocity = Vector2.zero;
                if (playerOnR)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                    _rigid.velocity = new Vector2(10, 0);
                    _anim.SetBool("IsRun", true);
                    yield return new WaitUntil(() => xWall != null);
                    _anim.SetBool("IsRun", false);
                    _rigid.velocity = Vector2.zero;
                    farFromPlayer = true;
                }
                else
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                    _rigid.velocity = new Vector2(-10, 0);
                    _anim.SetBool("IsRun", true);
                    yield return new WaitUntil(() => xWall != null);
                    _anim.SetBool("IsRun", false);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, new Vector2(1, 2.5f));

        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, new Vector2(2.5f, 1));
    }
}