using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static public PlayerManager instance = null;

    private Rigidbody2D rb2D;
    public GameObject player;

    [SerializeField] GameObject stopPanel;
    [SerializeField] private float speed = 5f;
    public int coin;

    [Header("Player Bomb")]
    public bool rightIsTrue;    //�÷��̾ ���� ���� �ִ� ����
    public int nowBombCount;    //���� �÷��̾ ������ �ִ� ��ź ����
    [SerializeField] float bombDeley = 0.7f;    //��ź ������
    [SerializeField] GameObject bomb, bombRange;    //��ź�� ��ź ����
    public float moveLocation = 5f;   //��ź�� ���󰡴� �Ÿ�

    private int mc;
    public int moveChange {
        set { mc = value; }
    }

    private void Awake()
    {
        player = this.gameObject;
        if (instance == null)
            instance = this;

        coin = DataManager.instance.afterData.goldenCoin;
        nowBombCount = DataManager.instance.afterData.bomb;
    }

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(Bomb());

        ServeItemManager.Instance.Gold = coin;
        ServeItemManager.Instance.Bomb = nowBombCount;
    }

    void Update()
    {
        if(DataManager.instance.nowPlayer.playerHp <= 0)
        {
            rb2D.velocity = Vector2.zero;
            return;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, y, 0);
        rb2D.velocity = dir.normalized * speed * mc;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (stopPanel.activeSelf == false)
            {
                stopPanel.SetActive(true);
                Time.timeScale = 0;
            }
            else if (stopPanel.activeSelf == true)
            {
                stopPanel.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    IEnumerator Bomb()
    {
        while (true)
        {
            if (nowBombCount > 0)
            {
                if (Input.GetKeyDown(KeyCode.Q))
                {
                    Debug.Log("��ź");
                    nowBombCount--;
                    ServeItemManager.Instance.Bomb = nowBombCount;

                    if (rightIsTrue)
                    {
                        GameObject go = Instantiate(bomb);
                        go.transform.position = this.transform.position;
                        moveLocation = Mathf.Abs(moveLocation);

                        yield return new WaitForSeconds(bombDeley);
                    }
                    else
                    {
                        GameObject go = Instantiate(bomb);
                        go.transform.position = this.transform.position;
                        if (moveLocation > 0)
                        {
                            moveLocation = -moveLocation;
                        }

                        yield return new WaitForSeconds(bombDeley);
                    }
                }
            }
            yield return null;
        }
    }
}
