using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour
{
    public static GoldManager Instance; 
    private int gold = 0;
    [SerializeField] private TextMeshProUGUI goldTxt;

    public int Gold
    {
        get => gold;
        set => gold = value;
    }
    private void Awake()
    {
        if(Instance != null)
        {
            Debug.LogError("Multiple GoldManger");
        }
        Instance = this;
    }

    void Update()
    {
        if(gold > 99)
            gold = 99;
        goldTxt.text = (gold < 10)? $"0{gold}" : $"{gold}";
        if(Input.GetKeyDown(KeyCode.V))
        {
            gold += 3;
        }
    }
}
