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

    [SerializeField] private Image playerUI;

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

        playerUI.sprite = item.GetComponent<SpriteRenderer>().sprite;

        //µÒº≈≥ ∏Æø° æ∆¿Ã≈€ √ﬂ∞°
        for (int i = 0; i < itemArr.Length; i++)
        {
            items.Add(itemArr[i].name, itemArr[i]);
        }

        cool = DataManager.instance.nowPlayer.activeItemCoolTime;
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
        if (collision.tag == "ActiveItem")
        {
            Debug.Log("æ◊∆º∫Í æ∆¿Ã≈€ »πµÊ Ω√µµ");
            string temp = item.name;
            item = items[collision.name];
            collision.name = temp;

            //FieldActiveItem fieldItem = collision.GetComponent<FieldActiveItem>();
            //string temp = fieldItem.ItemSkill.name;
            //Debug.Log(temp);
            //fieldItem.ItemSkill = item.ItemSkill;

            //item.ItemSkill = items[temp].ItemSkill;
            //playerUI.sprite = item.GetComponent<SpriteRenderer>().sprite;
        }
    }
}
