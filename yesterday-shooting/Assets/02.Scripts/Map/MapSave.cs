using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSave : MonoBehaviour
{
    [SerializeField] int roomCount = 12;

    GameObject[] isMap;

    void Start()
    {
        /*for (int i = 0; i < roomCount; i++)
        {
            if (GameObject.Find(i.ToString()) != null)
            {
                Debug.Log("甘捞 积己夌促!");
                isMap[i] = GameObject.Find($"{i}");
                DataManager.instance.nowPlayer.tlqkf[i] = isMap[i].transform.position;
                DataManager.instance.nowPlayer.tlqkftlqkf[i] = isMap[i].GetComponentInChildren<EnterRoom>().roomNumber;
            }
        }*/
    }

    bool tltltltl = true;

    private void Update()
    {
        /*if (tltltltl)
        {
            for (int i = 0; i < roomCount; i++)
            {
                if (GameObject.Find(i.ToString()) != null)
                {
                    Debug.Log("甘捞 积己夌促!");
                    isMap[i] = GameObject.Find($"{i}");
                    DataManager.instance.nowPlayer.tlqkf[i] = isMap[i].transform.position;
                    DataManager.instance.nowPlayer.tlqkftlqkf[i] = isMap[i].GetComponentInChildren<EnterRoom>().roomNumber;
                }
            }
            tltltltl = false;
        }*/
    }
}
