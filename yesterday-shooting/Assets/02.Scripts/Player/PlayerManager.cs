using System.Collections;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    static public PlayerManager instance = null;

    private Rigidbody2D rb2D;
    public GameObject player;

    [SerializeField] private GameObject stopPanel;
    public GameObject StopPanelㄴ
    {
        get { return stopPanel; }
    }
    [SerializeField] private float speed = 5f;
    int coin;

    [Header("Player Bomb")]
    public bool rightIsTrue;    //�÷��̾ ���� ���� �ִ� ����
    public int nowBombCount;    //���� �÷��̾ ������ �ִ� ��ź ����
    [SerializeField] float bombDeley = 0.7f;    //��ź ������
    [SerializeField] GameObject bomb, bombRange;    //��ź�� ��ź ����
    public float moveLocation = 5f;   //��ź�� ���󰡴� �Ÿ�

    private int mc = 1;
    public int moveChange {
        set { mc = value; }
    }

    private void Awake()
    {
        player = this.gameObject;
        if (instance == null)
            instance = this;

        //Debug.Log(DataManager.instance.afterData.bomb);
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
    public float delayTime = 0f;
    void Update()
    {
        if(DataManager.instance.nowPlayer.playerHp <= 0)
        {
            rb2D.velocity = Vector2.zero;
            return;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (stopPanel.activeSelf == false)
            {
                stopPanel.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
            }
            else if (stopPanel.activeSelf == true)
            {
                stopPanel.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
            }
        }

        if(delayTime > 3f)
        {
            PlayerItem.Instance.useInvincibleHand = false;
        }
        if(PlayerItem.Instance.useInvincibleHand)
        {
            delayTime += Time.deltaTime;
            rb2D.velocity = Vector2.zero;
            return;
        }
        if(PlayerItem.Instance.useIronArmor)
        {
            speed = 2f;
        }
        else
        {
            speed = 5f;
        }
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, y, 0);
        rb2D.velocity = dir.normalized * speed * mc;

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

                    DataManager.instance.afterData.bomb--;
                }
            }
            yield return null;
        }
    }
}
