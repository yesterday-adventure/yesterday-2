using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Stage1_1Boss : MonoBehaviour
{
    [SerializeField] GameObject hand;
    [SerializeField] GameObject ball;

    [SerializeField] float hp;
    float maxHp;
    [SerializeField] float speed;
    [Tooltip("플레이어와 보스의 거라")]
    [SerializeField] float distance = 10;
    [Tooltip("플레이어 근처 손 소환 범위")]
    [SerializeField] float summonRange;

    Rigidbody2D rb;
    Animator _animator;
    GameObject player;
    [SerializeField] private Slider slider;

    private bool walkState = false;
    private bool isAttacking = false;

    private void Awake()
    {
        maxHp = hp;
        _animator = transform.GetChild(0).GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        player = FindObjectOfType<PlayerHp>().transform.gameObject;
        StartCoroutine(this.Pattern());
    }

    private void Update()
    {
        if (walkState)
        {
            rb.velocity = (player.transform.position - transform.position).normalized * speed;
            _animator.SetBool("Walk", true);
        }
        else
        {
            rb.velocity = Vector2.zero;
            _animator.SetBool("Walk", false);
        }

        if (!isAttacking)
        {
            if (player.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector2(-1, 1);
            }
            else
            {
                transform.localScale = new Vector2(1, 1);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 4);

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, 6);
    }

    private IEnumerator Pattern()
    {
        while (hp > 0)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Debug.Log("패턴 실행");
            if (distance < 4)
            {
                //직접공격
                isAttacking = true;
                walkState = false;
                Attack();
                //소환하기
                for (int i = 0; i < 3; i++)
                {
                    Ball(i);
                    yield return new WaitForSeconds(0.3f);
                }
                yield return new WaitForSeconds(1f);
                walkState = true;
                isAttacking = false;
            } //공격
            else if (distance > 6)
            {
                //소환
                walkState = false;
                _animator.SetBool("Summon", true);
                yield return new WaitForSeconds(1);
                _animator.SetBool("Summon", false);
                walkState = true;
                for (int i = 1; i <= 4; i++)
                {
                    Summon();
                    yield return new WaitForSeconds(1);
                }
            } //소환
            else
            {
                walkState = true;
            } //걷기
            yield return new WaitForSeconds(1);
        }
    }

    private void Summon()
    {
        Vector2 summonPos = SetPos();
        //Instantiate(hand, new Vector2(summonPos.x, summonPos.y + 1.2f), Quaternion.identity);
        PoolManager.Instance.Pop(hand, new Vector2(summonPos.x, summonPos.y + 1.2f), Quaternion.identity);
    }

    private void Ball(int k)
    {
        for (int i = 0; i < 8; i++)
        {
            //Instantiate(ball, transform.position, Quaternion.Euler(0, 0, (i * 45) + (k * 22.5f)));
            PoolManager.Instance.Pop(ball, transform.position, Quaternion.Euler(0, 0, (i * 45) + (k * 22.5f)));
        }
    }

    private Vector2 SetPos()
    {
        return (Vector2)player.transform.position + UnityEngine.Random.insideUnitCircle * summonRange;
    }

    private void Attack()
    {
        _animator.SetBool("Attack", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            hp -= collision.GetComponent<BulletInfo>().Damage;
            slider.value = hp / maxHp;
        }
    }
}
