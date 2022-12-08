using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopExchange : MonoBehaviour
{
    [SerializeField] private int needMoney;
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
