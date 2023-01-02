using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOwner : MonoBehaviour
{
    [Header("무기")]
    [SerializeField] string[] shopWeapon;
    
    [Header("무기 가격")]
    [SerializeField] int[] weaponMinPrice;

    [Header("아이템")]
    [SerializeField] GameObject[] shopItem;
    
    [Header("아이템 가격")]
    [SerializeField] int[] itemMinPrice;

    [Header("포션")]
    [SerializeField] GameObject[] shopPotion;
    
    [Header("포션 가격")]
    [SerializeField] int[] potionMinPrice;

    void OnEnable()
    {
        SetWeapon(0);
        SetItem(1);
        SetItem(2);
        SetPotion(3);
        // for(int i = 0; i < 4; i++)
        // {
        //     int r = Random.Range(0,shopWeapon.Length);
        //     transform.GetChild(i).name = shopWeapon[r];
        //     transform.GetChild(i).GetComponent<ShopExchange>().NeedMoney = weaponPrice[r];
        // }
    }

    void SetWeapon(int i)
    {
        int r = Random.Range(0,shopWeapon.Length);
        transform.GetChild(i).name = shopWeapon[r];
        int plusPrice = weaponMinPrice[r] + (Random.Range(0,3) * 5);
        transform.GetChild(i).GetComponent<ShopExchange>().NeedMoney = plusPrice;
    }

    void SetItem(int i)
    {
        int r = Random.Range(0,shopItem.Length);
        //transform.GetChild(i).name = shopItem[r];
        int plusPrice = itemMinPrice[r] + (Random.Range(0,3) * 5);
        transform.GetChild(i).GetComponent<ShopExchange>().NeedMoney = plusPrice;
    }

    void SetPotion(int i)
    {
        int r = Random.Range(0,shopWeapon.Length);
        //transform.GetChild(i) = shopPotion[r];
        int plusPrice = potionMinPrice[r] + (Random.Range(0,3) * 5);
        transform.GetChild(i).GetComponent<ShopExchange>().NeedMoney = plusPrice;
    }
}
