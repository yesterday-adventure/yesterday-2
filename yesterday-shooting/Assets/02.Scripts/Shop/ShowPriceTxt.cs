using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShowPriceTxt : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI priceTxt;
    
    ShopExchange shop;
    private void Awake()
    {
        shop = GetComponent<ShopExchange>();
    }

    private void Update()
    {
        priceTxt.text = shop.NeedMoney.ToString();
    }
}
