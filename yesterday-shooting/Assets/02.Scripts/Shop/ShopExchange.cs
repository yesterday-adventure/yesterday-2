using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShopItem
{
    weapon = 1,
    activeItem = 2,
    potion = 3
}
public class ShopExchange : MonoBehaviour
{
    [SerializeField] private int needMoney;
    public ShopItem shopItem = ShopItem.weapon;
    public int NeedMoney
    {
        get => needMoney;
        set => needMoney = value;
    }
    public bool CanExchange()
    {
        if(GoldManager.Instance.Gold >= needMoney)
        {
            GoldManager.Instance.Gold -= needMoney;
            return true;
        }
        return false;
    }
}
