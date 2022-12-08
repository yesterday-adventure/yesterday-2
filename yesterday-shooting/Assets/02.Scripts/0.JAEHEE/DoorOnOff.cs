using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public enum Dir
{
    up,
    down,
    left,
    right
}
public class DoorOnOff : MonoBehaviour
{

    [SerializeField] GameObject upD;
    [SerializeField] GameObject downD;
    [SerializeField] GameObject leftD;
    [SerializeField] GameObject rightD;

    public Dir dir = Dir.up;

    int x = 5;
    int y = 6;
    [SerializeField] RandomMapSpawn _RMS;

    private void Awake()
    {
        //_RMS = GameObject.Find("SpawnMap/RandomMapSpawn").GetComponent<RandomMapSpawn>();
        //Debug.Log(_RMS);


        if (File.Exists(DataManager.instance.path + "TwoArr" + DataManager.instance.nowSlot.ToString()))
        {
            Debug.Log("2���� �迭 �޾ƿ���");
            DataManager.instance.TwoLoad();
            DataManager.instance.TwoSave(DataManager.instance.mapArrTwo, DataManager.instance.boolArrTwo);

        }
    }

    private void Start()
    {
        /*x = 5;
        y = 6;*/

        x = DataManager.instance.nowPlayer.x;
        y = DataManager.instance.nowPlayer.y;


        _RMS = GameObject.Find("SpawnMap/RandomMapSpawn").GetComponent<RandomMapSpawn>();
    }

    /*
        private void Update()
        {
            Collider2D hit = Physics2D.OverlapBox(transform.position, new Vector2(17.7f, 9.3f), 0, 1 << 10);
            if (hit == null)
            {
                if (_RMS.mapGrid[x + 1, y] == null)
                {
                    rightD.SetActive(true);
                }
                else
                {
                    rightD.SetActive(false);
                }

                if (_RMS.mapGrid[x - 1, y] == null)
                {
                    leftD.SetActive(true);
                }
                else
                {
                    leftD.SetActive(false);
                }
                if (_RMS.mapGrid[x, y + 1] == null)
                {
                    upD.SetActive(true);
                }
                else
                {
                    upD.SetActive(false);
                }
                if (_RMS.mapGrid[x, y - 1] == null)
                {
                    downD.SetActive(true);
                }
                else
                {
                    downD.SetActive(false);
                }
            }
            else
            {
                upD.SetActive(true);
                downD.SetActive(true);
                leftD.SetActive(true);
                rightD.SetActive(true);
            }
        }*/


    private void Update()
    {
        Collider2D hit = Physics2D.OverlapBox(transform.position, new Vector2(17.7f, 9.3f), 0, 1 << 10);

        if (hit == null)
        {
            if (_RMS.mapGrid[x + 1, y] == null)
            /*if (DataManager.instance.mapGrid[0].mapArr[x + 1] == null &&
                DataManager.instance.mapGrid[1].mapArr[y] == null)*/
            {
                rightD.SetActive(true);
                Debug.Log("������ �� ����");
            }
            else
            {
                rightD.SetActive(false);
                Debug.Log("������ �� ����");
            }


            if (_RMS.mapGrid[x - 1, y] == null)
            /*if (DataManager.instance.mapGrid[0].mapArr[x - 1] == null &&
                DataManager.instance.mapGrid[1].mapArr[y] == null)*/
            {
                Debug.Log("오른쪽 문 닫힘");//
                Debug.Log($"{x - 1}, {y}");
                leftD.SetActive(true);
            }
            else
            {
                Debug.Log("오른쪽 문 열림");
                Debug.Log($"{x - 1}, {y}");
                leftD.SetActive(false);
            }

            if (_RMS.mapGrid[x, y + 1] == null)
            /*if (DataManager.instance.mapGrid[0].mapArr[x] == null &&
                DataManager.instance.mapGrid[1].mapArr[y + 1] == null)*/
            {
                upD.SetActive(true);
            }
            else
            {
                upD.SetActive(false);
            }

            if (_RMS.mapGrid[x, y - 1] == null)
            /*if (DataManager.instance.mapGrid[0].mapArr[x] == null &&
                DataManager.instance.mapGrid[1].mapArr[y - 1] == null)*/
            {
                downD.SetActive(true);
            }
            else
            {
                downD.SetActive(false);
            }
        }
        else
        {
            upD.SetActive(true);
            downD.SetActive(true);
            leftD.SetActive(true);
            rightD.SetActive(true);
        }
        hit = Physics2D.OverlapBox(transform.position, new Vector2(17.7f, 9.3f), 0, 1 << 10); //���� ������ null
    }

    public void changePos()
    {
        if (dir == Dir.up)
            y++;
        else if (dir == Dir.down)
            y--;
        else if (dir == Dir.left)
            x--;
        else if (dir == Dir.right)
            x++;

        DataManager.instance.nowPlayer.x = x;
        DataManager.instance.nowPlayer.y = y;
    }

}
