using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviour
{
    public static PlayerItem Instance = null;
    [SerializeField] private GameObject usingParticle;
    public FieldActiveItem item = null;

    [SerializeField] private FieldActiveItem[] itemArr;
    Dictionary<string, FieldActiveItem> items = new Dictionary<string, FieldActiveItem>();

    public float cool = 0;

    //public float DataManager.instance.nowPlayer.addDamage = 0f;

    public bool useRustyRazorBlade = true;

    public bool useMarksmansEye = false;
    public bool useGodsDice = false;
    public bool useIronArmor = false;

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

        if (item != null)
        {
            playerUI1.sprite = item.GetComponent<SpriteRenderer>().sprite;
            playerUI2.sprite = item.GetComponent<SpriteRenderer>().sprite;
        }

        //��ųʸ��� ������ �߰�
        for (int i = 0; i < itemArr.Length; i++)
        {
            items.Add(itemArr[i].name, itemArr[i]);
        }

        cool = DataManager.instance.nowPlayer.activeItemCoolTime;
    }

    private void Start()
    {
        //�ٴڿ� ������ ������ �־��ִ� ��.
        if (!Select.instance.newStart)  //ó�� �����ϴ� ���� �ƴ϶��
        {

        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cool <= 0)
        {
            if (item.Use())
                Instantiate(usingParticle, transform.position, Quaternion.identity);
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
            //Debug.Log("��Ƽ�� ������ ȹ�� �õ�");
            string temp = item.name;
            Debug.Log(temp);
            Debug.Log(collision.gameObject.name);
            item = items[collision.gameObject.name];
            collision.gameObject.name = temp;

            ItemNameAnimation.Instance.InitText(item.ItemSkill.titleTxt, item.ItemSkill.captionTxt);
        }
    }
}
