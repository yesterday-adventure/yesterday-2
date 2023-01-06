using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerItem : MonoBehaviour
{
    public static PlayerItem Instance = null;
    [SerializeField] private GameObject usingParticle;
    public FieldActiveItem item = null;

    [SerializeField] private FieldActiveItem[] itemArr;
    Dictionary<string, FieldActiveItem> items = new Dictionary<string, FieldActiveItem>();

    public float cool = 0;

    //public float DataManager.instance.nowPlayer.addDamage = 0f;

    public bool useRustyRazorBlade = false;
    public bool useMarksmansEye = false;
    public bool useGodsDice = false;
    public bool useIronArmor = false;
    public bool useInvincibleHand = false;

    public float plusMarionette = 0f;

    [SerializeField] private Image playerUI1;
    [SerializeField] private Image playerUI2;
    [SerializeField] private Image usingImage;

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
        useRustyRazorBlade = false;//먼 버그징..?

        if (DataManager.instance.nowPlayer.activeItem == null)
        DataManager.instance.nowPlayer.activeItem = item.name;
            //초기값 저장하는거
    }

    private void Start()
    {
        //Debug.Log(DataManager.instance.nowPlayer.activeItem);
        //�ٴڿ� ������ ������ �־��ִ� ��.
        if (!Select.instance.newStart)  //ó�� �����ϴ� ���� �ƴ϶��
        {
        //Debug.Log(items[DataManager.instance.nowPlayer.activeItem]);
            item = items[DataManager.instance.nowPlayer.activeItem];
            cool = DataManager.instance.nowPlayer.activeItemCoolTime;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cool <= 0)
        {
            if (item.Use())
            {
                Instantiate(usingParticle, transform.position, Quaternion.identity);
                cool = item.ItemSkill.maxCool;
                DataManager.instance.nowPlayer.activeItemCoolTime = cool;


                usingImage.transform.localScale = new Vector2(1, 1);
                usingImage.color = Color.white;
                Sequence seq = DOTween.Sequence()
                .Append(usingImage.transform.DOScale(new Vector2(5, 5), 1.2f).SetEase(Ease.OutQuart))
                .Join(usingImage.DOFade(0, 1.3f));
            }
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
            usingImage.sprite = collision.GetComponent<SpriteRenderer>().sprite;
            //Debug.Log("��Ƽ�� ������ ȹ�� �õ�");
            string temp = item.name;
            Debug.Log(temp);
            Debug.Log(collision.gameObject.name);
            item = items[collision.gameObject.name];

            DataManager.instance.nowPlayer.activeItem = collision.gameObject.name;

            collision.gameObject.name = temp;

            ItemNameAnimation.Instance.InitText(item.ItemSkill.titleTxt, item.ItemSkill.captionTxt);
        }
    }
}
