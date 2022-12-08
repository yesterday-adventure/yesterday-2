using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

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

    private void Awake()
    {
        if (File.Exists(DataManager.instance.path + "TwoArr" + DataManager.instance.nowSlot.ToString()))
        {
            mapGrid = new Map[xIndex + 1, yIndex + 1];

            mapGrid[5, 6] = maps;

            for (int i = 0; i < DataManager.instance.nowPlayer.mapGrid.Length; i += 2) //21번 만큼 돌림, 0, 2, 4, 6, 8...
            {
                mapGrid[DataManager.instance.nowPlayer.mapGrid[i], 
                DataManager.instance.nowPlayer.mapGrid[i + 1]] = maps;
                if (mapGrid[DataManager.instance.nowPlayer.mapGrid[i],
                DataManager.instance.nowPlayer.mapGrid[i + 1]] != null)
                {
                    Debug.Log(mapGrid[DataManager.instance.nowPlayer.mapGrid[i],
                    DataManager.instance.nowPlayer.mapGrid[i + 1]]);

                    Debug.Log($"{DataManager.instance.nowPlayer.mapGrid[i]}, {DataManager.instance.nowPlayer.mapGrid[i + 1]}");
                }
                Debug.Log("mapGrid에 값 넣어주기");
            }
            //Debug.Log($"{mapGrid[0, 0]}");
        }
    }

    void Start()
    {
        if (Select.instance.newStart)
        {
            /*Debug.Log("데이터 배열 저장");
            DataManager.instance.mapGrid.Add(new MapArr(new Map[10]));
            DataManager.instance.mapGrid.Add(new MapArr(new Map[11]));*/

            //map[0].mapArr[5] = _map
            DataManager.instance.mapGrid[0].mapArr[5] = maps;
            DataManager.instance.mapGrid[1].mapArr[6] = maps;

            //MapArrTwo mapArrTwo = new MapArrTwo(DataManager.instance.mapGrid);
            DataManager.instance.TwoSave(DataManager.instance.mapArrTwo);
            //DataManager.instance.TwoSave(mapArrTwo);

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
            number = 0;
            Debug.Log("�ʸʸ�");
            if (DataManager.instance.nowPlayer.roomPos != null && DataManager.instance.nowPlayer.roomNumber != null)
            {
                // ��ġ���� �� ���ڸ� ���ؼ� ����
                for (int i = 0; i < DataManager.instance.nowPlayer.roomPos.Length; i++)
                {
                    Debug.Log("MapSpaw?");
                    //DataManager.instance.nowPlayer.roomPos[i]
                    Instantiate(randomMap[DataManager.instance.nowPlayer.roomNumber[i] - 1], DataManager.instance.nowPlayer.roomPos[i], Quaternion.identity);

                    //여기에다가 미니맵 스폰 넣으면 될 듯. 안되면 자살
                    GameObject spawnMiniMap = Instantiate(monsterMinimap, minimap.transform);

                    spawnMiniMap.transform.localPosition = maps.MiniMapSetPos(DataManager.instance.nowPlayer.mapGrid[number] - 5, DataManager.instance.nowPlayer.mapGrid[number + 1] - 6);

                    number += 2;
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
                mapGirdSave(x, y);
                Debug.Log($"처음으로 생성되는 맵의 X 좌표는 : {x}, Y 좌표는 : {y}");
                DataManager.instance.mapGrid[0].mapArr[x] = maps;
                DataManager.instance.twoBoolArr[0].boolArr[x] = true;

                DataManager.instance.mapGrid[1].mapArr[y] = maps;
                DataManager.instance.twoBoolArr[1].boolArr[y] = true;

                MapArrTwo mapArrTwo = new MapArrTwo(DataManager.instance.mapGrid);
                BoolArrTwo boolArrTwo= new BoolArrTwo(DataManager.instance.twoBoolArr);
                DataManager.instance.TwoSave(mapArrTwo);
                DataManager.instance.TwoSave(null, boolArrTwo);
                RoomCount++;
            }
        }
    }

    int number = 0;

    void mapGirdSave(int own, int two)
    {
        try
        {
            DataManager.instance.nowPlayer.mapGrid[number] = own;
            number++;
            DataManager.instance.nowPlayer.mapGrid[number] = two;
            if (number <= 21)
            {
             number++;
            }
        }
        catch
        {
            Debug.Log($"현재 맵 그리드 숫자 {number}, 넣으려는 숫자 {own}, {two}");
        }

    }

    public GameObject PopMap()
    {
        int random = Random.Range(0, randomMap.Length);
        GameObject returnMap = randomMap[random];
        return returnMap;
    }
}