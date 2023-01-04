using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviour
{
    public static PlayerItem Instance = null;

    public FieldActiveItem item = null;

    [SerializeField] private FieldActiveItem[] itemArr;
    Dictionary<string, FieldActiveItem> items = new Dictionary<string, FieldActiveItem>();

    public float cool = 0;

    public bool useGodsDice = false;

    [SerializeField] private Image playerUI1;
    [SerializeField] private Image playerUI2;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple PlayerItem Instance running");
        }

        playerUI1.sprite = item.GetComponent<SpriteRenderer>().sprite;
        playerUI2.sprite = item.GetComponent<SpriteRenderer>().sprite;

        //딕셔너리에 아이템 추가
        for (int i = 0; i < itemArr.Length; i++)
        {
            items.Add(itemArr[i].name, itemArr[i]);
        }

        cool = DataManager.instance.nowPlayer.activeItemCoolTime;
    }

    private void Start()
    {
        //바닥에 떨어진 아이템 넣어주는 곳.
        if (!Select.instance.newStart)  //처음 시작하는 것이 아니라면
        {

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cool <= 0)
        {
            if (item.Use())
                cool = item.ItemSkill.maxCool;
        }

        if (Input.GetKey(KeyCode.R) && Input.GetKeyDown(KeyCode.I))
            cool = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ActiveItem" && ItemNameAnimation.Instance.IsChanging == false)
        {
            playerUI1.sprite = collision.GetComponent<SpriteRenderer>().sprite;
            playerUI2.sprite = collision.GetComponent<SpriteRenderer>().sprite;
            //Debug.Log("액티브 아이템 획득 시도");
            string temp = item.name;
            Debug.Log(temp);
            Debug.Log(collision.gameObject.name);
            item = items[collision.gameObject.name];
            collision.gameObject.name = temp;

            ItemNameAnimation.Instance.InitText(item.ItemSkill.titleTxt,item.ItemSkill.captionTxt);
        }
    }
}
