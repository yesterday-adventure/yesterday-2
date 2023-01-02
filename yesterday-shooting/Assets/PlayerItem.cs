using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItem : MonoBehaviour
{
    public static PlayerItem Instance = null;

    public FieldActiveItem item = null;

    [SerializeField] private FieldActiveItem[] itemarr;
    Dictionary<string, FieldActiveItem> items = new Dictionary<string, FieldActiveItem>();

    public int cool = 0;

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
            Debug.LogError("PlayerItem Multiple");
        }

        playerUI.sprite = item.GetComponent<SpriteRenderer>().sprite;

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
            ItemSkill temp = collision.transform.GetComponent<FieldActiveItem>().ItemSkill;
            Debug.Log(temp);
            Debug.Log(temp.transform.name);
            collision.transform.GetComponent<FieldActiveItem>().ItemSkill = item.ItemSkill;
            item.ItemSkill = temp;
            playerUI.sprite = item.GetComponent<SpriteRenderer>().sprite;
        }
    }
}
