using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasicItemManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bombText;
    [SerializeField] TextMeshProUGUI goldenCoinText;
    //[SerializeField] TextMeshProUGUI goldenKeyText;

    private void Update()
    {
        if (DataManager.instance.nowPlayer.bomb < 10)
        {
            bombText.text = "0" + DataManager.instance.nowPlayer.bomb.ToString();
        }
        else
        {
            bombText.text = DataManager.instance.nowPlayer.bomb.ToString();
        }

        if (DataManager.instance.nowPlayer.goldenCoin < 10)
        {
            goldenCoinText.text = "0" + DataManager.instance.nowPlayer.goldenCoin.ToString();
        }
        else
        {
            goldenCoinText.text = DataManager.instance.nowPlayer.goldenCoin.ToString();
        }

        if (DataManager.instance.nowPlayer.goldenKey < 10)
        {
            goldenKeyText.text = "0" + DataManager.instance.nowPlayer.goldenKey.ToString();
        }
        else
        {
            goldenKeyText.text = DataManager.instance.nowPlayer.goldenKey.ToString();
        }
    }
}
