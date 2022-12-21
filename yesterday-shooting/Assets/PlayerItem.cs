using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItem : MonoBehaviour
{
    public ItemSkil item = null;

    [SerializeField] private ItemSkil[] itemarr;
    Dictionary<string, ItemSkil> items = new Dictionary<string, ItemSkil>();

    public static PlayerItem Instance = null;
    public int cool = 0;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && cool <= 0)
        {
            item.Skil();
            cool = item.maxColl;
        }
    }
}
