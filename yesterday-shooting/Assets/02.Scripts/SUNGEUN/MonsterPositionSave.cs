using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPositionSave : MonoBehaviour
{
    //[SerializeField] List<GameObject> monsterPosition = new List<GameObject>();
    [SerializeField] GameObject[] monsterPosition = new GameObject[40];
    //int[] roomNumber = new int[14] {0, 6, 4, 2, 3, 8, 0, 4, 4, 4, 2, 3, 0, 0};

    /*// Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            monsterPosition[i].transform.position = DataManager.instance.nowPlayer.mosterPosition[i];
        }
    }

    public void MonsterPositionS()
    {
        for (int i = 0; i < 40; i++)
        {
            DataManager.instance.nowPlayer.mosterPosition[i] = monsterPosition[i].transform.position;
            DataManager.instance.SaveData();
        }
    }*/
}
