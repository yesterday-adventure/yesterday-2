using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ServeItemManager : MonoBehaviour
{
    public static ServeItemManager Instance; 
    private int gold;
    private int bomb;
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
        if(gold > 99) gold = 99;

        goldTxt.text = (gold < 10)? $"0{gold}" : $"{gold}";
        
        if(Input.GetKeyDown(KeyCode.V))
        {
            Debug.Log("코인증가");
            gold += 3;
            DataManager.instance.nowPlayer.goldenCoin = gold;
        }

        if(bomb > 99) {
            bomb = 99;
        }
        
        bombTxt.text = (bomb < 10)? $"0{bomb}" : $"{bomb}";
        
        if(Input.GetKeyDown(KeyCode.B))
        {
            bomb += 3;
            FindObjectOfType<PlayerManager>().nowBombCount += 3;
        }
    }
}
