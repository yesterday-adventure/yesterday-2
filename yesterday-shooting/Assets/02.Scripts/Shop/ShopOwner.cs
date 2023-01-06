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
    [SerializeField] string[] shopItem;
    
    [Header("아이템 가격")]
    [SerializeField] int[] itemMinPrice;

    [Header("포션")]
    [SerializeField] string[] shopPotion;
    
    [Header("포션 가격")]
    [SerializeField] int[] potionMinPrice;

    void Start()
    {
        if (Select.instance.newStart)
        {
            Debug.Log("아이템 생성하기");
            SetWeapon(0);
            SetItem(1);
            SetItem(2);
            SetPotion(3);
        }
        else
        {

            Debug.Log("아이템 불러오기");

            if (gameObject.transform.parent.name == "Shop1")
            {
                for (int i = 0; i < 4; i++)
                {
                    if (DataManager.instance.nowPlayer.shopItem1[i] == null && DataManager.instance.nowPlayer.shopPlusPrice1[i] == 0)
                    {
                        continue;
                    }
                    Debug.Log(DataManager.instance.nowPlayer.shopItem1[i]);
                    transform.GetChild(i).name = DataManager.instance.nowPlayer.shopItem1[i];
                    transform.GetChild(i).GetComponent<ShopExchange>().NeedMoney = DataManager.instance.nowPlayer.shopPlusPrice1[i];
                }
            }
            else if (gameObject.transform.parent.name == "Shop2")
            {
                for (int i = 0; i < 4; i++)
                {
                    if (DataManager.instance.nowPlayer.shopItem2[i] == null && DataManager.instance.nowPlayer.shopPlusPrice2[i] == 0)
                    {
                        continue;
                    }
                    transform.GetChild(i).name = DataManager.instance.nowPlayer.shopItem2[i];
                    transform.GetChild(i).GetComponent<ShopExchange>().NeedMoney = DataManager.instance.nowPlayer.shopPlusPrice2[i];
                }
            }
        }
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

        Debug.Log(gameObject.transform.parent.name);
            
        if (gameObject.transform.parent.name == "Shop1")
        {
            Debug.Log(shopWeapon[r]);
            DataManager.instance.nowPlayer.shopItem1[i] = shopWeapon[r];
            DataManager.instance.nowPlayer.shopPlusPrice1[i] = plusPrice;
        }
        else if (gameObject.transform.parent.name == "Shop2")
        {
            DataManager.instance.nowPlayer.shopItem2[i] = shopWeapon[r];
            DataManager.instance.nowPlayer.shopPlusPrice2[i] = plusPrice;
        }
    }

    void SetItem(int i)
    {
        int r = Random.Range(0,shopItem.Length);
        transform.GetChild(i).name = shopItem[r];
        int plusPrice = itemMinPrice[r] + (Random.Range(0,3) * 5);
        transform.GetChild(i).GetComponent<ShopExchange>().NeedMoney = plusPrice;

        if (gameObject.transform.parent.name == "Shop1")
        {
            Debug.Log (shopItem[r]);
            DataManager.instance.nowPlayer.shopItem1[i] = shopItem[r];
            DataManager.instance.nowPlayer.shopPlusPrice1[i] = plusPrice;
        }
        else if (gameObject.transform.parent.name == "Shop2")
        {
            DataManager.instance.nowPlayer.shopItem2[i] = shopItem[r];
            DataManager.instance.nowPlayer.shopPlusPrice2[i] = plusPrice;
        }
    }

    void SetPotion(int i)
    {
        int r = Random.Range(0,shopPotion.Length);
        transform.GetChild(i).name = shopPotion[r];
        int plusPrice = potionMinPrice[r] + (Random.Range(0,3) * 5);
        transform.GetChild(i).GetComponent<ShopExchange>().NeedMoney = plusPrice;

        if (gameObject.transform.parent.name == "Shop1")
        {
            DataManager.instance.nowPlayer.shopItem1[i] = shopPotion[r];
            DataManager.instance.nowPlayer.shopPlusPrice1[i] = plusPrice;
        }
        else if (gameObject.transform.parent.name == "Shop2")
        {
            DataManager.instance.nowPlayer.shopItem2[i] = shopPotion[r];
            DataManager.instance.nowPlayer.shopPlusPrice2[i] = plusPrice;
        }
    }
}
