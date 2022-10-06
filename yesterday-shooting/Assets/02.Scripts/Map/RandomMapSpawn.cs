using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapSpawn : MonoBehaviour
{
    [SerializeField] CreateMiniMap createMiniMap;
    [SerializeField] Map maps;
    public Map[,] mapGrid = null;
    public CreateMiniMap[,] createMiniMapA = null;
    [SerializeField] GameObject[] randomMap;

    private int xIndex = 9;
    private int yIndex = 10;

    private int RoomCount = 0;
    private int NearRoomCount = 0;

    [SerializeField] int maxRoomCount;

    // ���� ����
    [SerializeField] int roomCount = 12;
    GameObject[] isMap = new GameObject[12];


    void Start()
    {
        if(Select.instance.newStart)
        {
            mapGrid = new Map[xIndex + 1, yIndex + 1];
            InputStartMap(mapGrid, maps);
            while (RoomCount < maxRoomCount)
            {
                RandomSpawn(mapGrid, maps);
            }


            //���������ä�
            for (int i = 1; i < roomCount + 1; i++)
            {
                if (GameObject.Find(i.ToString()) != null)
                {
                    Debug.Log("���� �������!");
                    isMap[i] = GameObject.Find(i.ToString());
                    DataManager.instance.nowPlayer.roomPos[i] = isMap[i].transform.position;
                    DataManager.instance.nowPlayer.roomNumber[i] = isMap[i].GetComponentInChildren<EnterRoom>().roomNumber;
                }
                else
                {
                    Debug.Log("���� �����Ǵٸ��Ҵ�!");
                }
                    Debug.Log("���� ������!");

            }
        }
        else
        {
            Debug.Log("�ʸʸ�");
            if (DataManager.instance.nowPlayer.roomPos != null && DataManager.instance.nowPlayer.roomNumber != null)
            {
                // ��ġ���� �� ���ڸ� ���ؼ� ����
                for (int i = 0; i < DataManager.instance.nowPlayer.roomPos.Length; i++)
                {
                    Debug.Log("�ʸʸ��� ���� �ǳ� ��¥��?");
                    //DataManager.instance.nowPlayer.roomPos[i]
                    Instantiate(randomMap[DataManager.instance.nowPlayer.roomNumber[i]], DataManager.instance.nowPlayer.roomPos[i], Quaternion.identity);
                }
            }
        }
    }

    void InputStartMap(Map[,] map, Map _map)
    {
        map[5, 6] = _map;
    }

    void RandomSpawn(Map[,] map, Map _map)
    {
        NearRoomCount = 0;
        int x = Random.Range(1, xIndex);
        int y = Random.Range(1, yIndex);
        if (map[x, y] == null)
        {
            if (map[x + 1, y] != null)
                NearRoomCount++;
            if (map[x - 1, y] != null)
                NearRoomCount++;
            if (map[x, y + 1] != null)
                NearRoomCount++;
            if (map[x, y - 1] != null)
                NearRoomCount++;

            if (NearRoomCount == 1)
            {
                GameObject spawnMap = Instantiate(PopMap(), _map.SetPos(x, y), Quaternion.identity);
                //spawnMap.name = spawnMap.name.Replace("(Clone)", "");

                spawnMap.name = $"{RoomCount + 1}";
                spawnMap.transform.GetComponent<EnterRoom>().roomNumber = RoomCount + 1;

                map[x, y] = _map;
                RoomCount++;
            }
        }
    }

    public GameObject PopMap()
    {
        int random = Random.Range(0, randomMap.Length);
        GameObject returnMap = randomMap[random];
        return returnMap;
    }
}