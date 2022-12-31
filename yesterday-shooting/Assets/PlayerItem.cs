using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public static PlayerItem Instance = null;

    public ItemSkill item = null;

    [SerializeField] private ItemSkill[] itemarr;
    Dictionary<string, ItemSkill> items = new Dictionary<string, ItemSkill>();

    public int cool = 0;

    public bool useGodsDice = false;

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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && cool <= 0)
        {
            if (item.Skill())
                cool = item.maxColl;
        }

        if (Input.GetKey(KeyCode.R) && Input.GetKeyDown(KeyCode.I))
            cool = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "ActiveItem")
        {
            ItemSkill temp = item;
            item = collision.GetComponent<ItemSkill>();
        }
    }
}
