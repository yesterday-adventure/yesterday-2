using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOwner : MonoBehaviour
{
    [SerializeField] string[] shopItem;
    [SerializeField] int[] price;

    void Start()
    {
        for(int i = 0; i < 4; i++)
        {
            int r = Random.Range(0,shopItem.Length);
            transform.GetChild(i).name = shopItem[r];
            transform.GetChild(i).GetComponent<ShopExchange>().NeedMoney = price[r];
        }
    }
}
