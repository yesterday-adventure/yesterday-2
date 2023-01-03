using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ServeItemManager : MonoBehaviour
{
    public static ServeItemManager Instance; 
    private int gold = 0;
    private int bomb = 0;
    [SerializeField] private TextMeshProUGUI goldTxt;
    [SerializeField] private TextMeshProUGUI bombTxt;

    public int Gold
    {
        get => gold;
        set => gold = value;
    }
    public int Bomb
    {
        get => bomb;
        set => bomb = value;
    }
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
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

        if(bomb > 99) {
            bomb = 99;
        }
            bombTxt.text = (bomb < 10)? $"0{bomb}" : $"{bomb}";
        if(Input.GetKeyDown(KeyCode.B))
        {
            bomb += 3;
        }
    }
}
