using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private Transform _playerTrm;
    public Transform PlayerTrm => _playerTrm;

    [SerializeField] private Transform mapTrm;
    public Transform MapTrm{
        get => mapTrm;
        set => mapTrm = value;
    }
    private void Awake()
    {
        _playerTrm = GameObject.Find("Player").transform;

        if(Instance != null) // ���� ó��
        {
            Debug.LogError("Multiple Gamemanager is running!");
        }
        Instance = this;
        MapManager.Instance = new MapManager();
    }
    // public void ChangeMap()
    // {
    //     mapTrm = Physics2D.OverlapBox(_playerTrm.position,new Vector2(1,1), 1, 1 << 11).transform.parent;
    // }
}
