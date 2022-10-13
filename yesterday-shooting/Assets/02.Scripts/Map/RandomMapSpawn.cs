using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapSpawn : MonoBehaviour
{
    [SerializeField] Map maps;
    public Map[,] mapGrid;
    [SerializeField] GameObject[] randomMap;

    private int xIndex = 9;
    private int yIndex = 10;

    private int RoomCount = 0;
    private int NearRoomCount = 0;

    [SerializeField] int maxRoomCount;

    [SerializeField] int roomCount = 12;
    public GameObject[] isMap = new GameObject[12];

    [SerializeField] GameObject monsterMinimap;
    [SerializeField] GameObject minimap;

    void Start()
    {
        if (Select.instance.newStart)
        {
            DataManager.instance.mapGrid.Add(new MapArr(new Map[11]));
            DataManager.instance.mapGrid.Add(new MapArr(new Map[12]));

            //map[0].mapArr[5] = _map
            DataManager.instance.mapGrid[0].mapArr[5] = maps;

            MapArrTwo mapArrTwo = new MapArrTwo(DataManager.instance.mapGrid);
            DataManager.instance.TwoSave(mapArrTwo);

            //DataManager.instance.nowPlayer.
            mapGrid = new Map[xIndex + 1, yIndex + 1];
            InputStartMap(/*DataManager.instance.nowPlayer.*/mapGrid, maps);
            //InputStartMapp(DataManager.instance.mapGrid, maps);
            while (RoomCount < maxRoomCount)
            {
                RandomSpawn(/*DataManager.instance.nowPlayer.*/mapGrid, maps);
                //RandomSpawnn(DataManager.instance.mapGrid, maps);
            }


            //���������ä�
            for (int i = 1; i < roomCount + 1; i++)
            {
                if (GameObject.Find(i.ToString()) != null)
                {
                    //Debug.Log("���� �������!");
                    isMap[i - 1] = GameObject.Find(i.ToString());
                    DataManager.instance.nowPlayer.roomPos[i - 1] = isMap[i - 1].transform.position;
                    DataManager.instance.nowPlayer.roomNumber[i - 1] = isMap[i - 1].GetComponentInChildren<EnterRoom>().roomNumber;
                }
                else
                {
                    //Debug.Log("���� �����Ǵٸ��Ҵ�!");
                }
                //Debug.Log("���� ������!");

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
                    Instantiate(randomMap[DataManager.instance.nowPlayer.roomNumber[i] - 1], DataManager.instance.nowPlayer.roomPos[i], Quaternion.identity);
                }
            }
        }
    }

    void InputStartMap(Map[,] map, Map _map)
    {
        map[5, 6] = _map;

        //map[DataManager.instance.mapGrid[0].mapArr[5], DataManager.instance.mapGrid[1].mapArr[6]] = _map; 
    }




    void InputStartMapp(List<MapArr> map, Map _map)
    {
        //map[5, 6] = _map;

        map[0].mapArr[5] = _map; 
        map[1].mapArr[6] = _map; 
    }



    //no data save
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

                GameObject spawnMiniMap = Instantiate(monsterMinimap, minimap.transform);

                spawnMiniMap.transform.localPosition = _map.MiniMapSetPos(x-5,y-6);
                //spawnMap.name = spawnMap.name.Replace("(Clone)", "");


                spawnMap.name = $"{RoomCount + 1}";
                //spawnMap.transform.GetComponent<EnterRoom>().roomNumber = RoomCount + 1;

                map[x, y] = _map;
                DataManager.instance.mapGrid[0].mapArr[x] = maps;
                DataManager.instance.mapGrid[1].mapArr[y] = maps;
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