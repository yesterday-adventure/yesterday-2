using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RandomMapSpawn : MonoBehaviour
{
    public static RandomMapSpawn Instance = null;
    [SerializeField] public Map maps;
    public Map[,] mapGrid;
    [SerializeField] List<GameObject> randomMap = new List<GameObject>();
    private int xIndex = 9;
    private int yIndex = 10;

    private int RoomCount = 0;
    private int NearRoomCount = 0;

    [SerializeField] int maxRoomCount;
    [SerializeField] int roomCount = 12;

    public GameObject[] isMap = new GameObject[12];
    public GameObject shop;
    public GameObject bossMap;

    [SerializeField] GameObject monsterMinimap;
    [SerializeField] GameObject shopMinimap;
    [SerializeField] GameObject bossMinimap;
    [SerializeField] GameObject minimap;
    [SerializeField] GameObject playerPos;
    public GameObject showPlayerPos;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Debug.LogError("RandomMapSpawn Multiples");
        //파일 있으면 불러와줌
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
                    //Debug.Log(mapGrid[DataManager.instance.nowPlayer.mapGrid[i],
                    //DataManager.instance.nowPlayer.mapGrid[i + 1]]);

                    //Debug.Log($"{DataManager.instance.nowPlayer.mapGrid[i]}, {DataManager.instance.nowPlayer.mapGrid[i + 1]}");
                }
                //Debug.Log("mapGrid에 값 넣어주기");
            }
        }

        if (Select.instance.newStart)
        {
            DataManager.instance.mapGrid[0].mapArr[5] = maps;
            DataManager.instance.mapGrid[1].mapArr[6] = maps;

            DataManager.instance.TwoSave(DataManager.instance.mapArrTwo);

            mapGrid = new Map[xIndex + 1, yIndex + 1];
            InputStartMap(mapGrid, maps);
            while (RoomCount < maxRoomCount)
            {
                RandomSpawn(mapGrid, maps);
            }
            InputShopMap(mapGrid, maps);
            InputShopMap(mapGrid, maps);  
            InputBossMap(mapGrid, maps);


            for (int i = 1; i < roomCount + 1; i++)     //13번 반복
            {
                if (GameObject.Find(i.ToString()) != null)
                {
                    isMap[i - 1] = GameObject.Find(i.ToString());
                    DataManager.instance.nowPlayer.roomPos[i - 1] = isMap[i - 1].transform.position;
                    DataManager.instance.nowPlayer.roomNumber[i - 1] = isMap[i - 1].GetComponentInChildren<EnterRoom>().roomNumber;
                }
            }
            showPlayerPos = Instantiate(playerPos, minimap.transform);
            showPlayerPos.transform.localPosition = maps.MiniMapSetPos(0, 0);

        }
        else
        {
            roomSaveNumber = 0;
            //Debug.Log("맵 생성");
            if (DataManager.instance.nowPlayer.roomPos != null && DataManager.instance.nowPlayer.roomNumber != null)
            {
                for (int i = 0; i < DataManager.instance.nowPlayer.roomPos.Length; i++)     //12 + 1 = 13
                {
                    //Debug.Log("MapSpaw?");
                    Instantiate(randomMap[DataManager.instance.nowPlayer.roomNumber[i] - 1], DataManager.instance.nowPlayer.roomPos[i], Quaternion.identity);
                    //미니맵
                    GameObject spawnMiniMap = Instantiate(monsterMinimap, minimap.transform);
                    spawnMiniMap.transform.localPosition = maps.MiniMapSetPos(DataManager.instance.nowPlayer.mapGrid[roomSaveNumber] - 5, DataManager.instance.nowPlayer.mapGrid[roomSaveNumber + 1] - 6);

                    roomSaveNumber += 2;
                }
            }

            //map Script
            mapGrid[DataManager.instance.nowPlayer.mapShopAndBoss[0], DataManager.instance.nowPlayer.mapShopAndBoss[1]] = maps;
            mapGrid[DataManager.instance.nowPlayer.mapShopAndBoss[2], DataManager.instance.nowPlayer.mapShopAndBoss[3]] = maps;

            //Shop
            GameObject spawnShopMap = Instantiate(shop, maps.SetPos(DataManager.instance.nowPlayer.mapShopAndBoss[0], DataManager.instance.nowPlayer.mapShopAndBoss[1]), Quaternion.identity);
            GameObject spawnShopMiniMap = Instantiate(shopMinimap, minimap.transform);
            spawnShopMiniMap.transform.localPosition = maps.MiniMapSetPos(DataManager.instance.nowPlayer.mapShopAndBoss[0] - 5, DataManager.instance.nowPlayer.mapShopAndBoss[1] - 6);
            spawnShopMap.name = $"Shop1";

            //Shop
            GameObject spawnShopMap2 = Instantiate(shop, maps.SetPos(DataManager.instance.nowPlayer.mapShopAndBoss[2], DataManager.instance.nowPlayer.mapShopAndBoss[3]), Quaternion.identity);
            GameObject spawnShopMiniMap2 = Instantiate(shopMinimap, minimap.transform);
            spawnShopMiniMap2.transform.localPosition = maps.MiniMapSetPos(DataManager.instance.nowPlayer.mapShopAndBoss[2] - 5, DataManager.instance.nowPlayer.mapShopAndBoss[3] - 6);
            spawnShopMap2.name = $"Shop2";

            //Boss
            GameObject spawnBossMap = Instantiate(bossMap, maps.SetPos(DataManager.instance.nowPlayer.mapShopAndBoss[4], DataManager.instance.nowPlayer.mapShopAndBoss[5]), Quaternion.identity);
            GameObject spawnBossMiniMap = Instantiate(bossMinimap, minimap.transform);
            spawnBossMiniMap.transform.localPosition = maps.MiniMapSetPos(DataManager.instance.nowPlayer.mapShopAndBoss[4] - 5, DataManager.instance.nowPlayer.mapShopAndBoss[5] - 6);
            spawnBossMap.name = $"Boss";


            showPlayerPos = Instantiate(playerPos, minimap.transform);
            showPlayerPos.transform.localPosition = maps.MiniMapSetPos(CameraMove.Instance.xIndex, CameraMove.Instance.yIndex);
        }
    }

    void Start()
    {
        
    }

    void InputStartMap(Map[,] map, Map _map)
    {
        map[5, 6] = _map;
    }

    void InputStartMapp(List<MapArr> map, Map _map)
    {
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
                randomMap.Remove(randomMap[random]);

                GameObject spawnMiniMap = Instantiate(monsterMinimap, minimap.transform);

                spawnMiniMap.transform.localPosition = _map.MiniMapSetPos(x - 5, y - 6);


                spawnMap.name = $"{RoomCount + 1}";

                map[x, y] = _map;
                mapGirdSave(x, y);
                //Debug.Log($"처음으로 생성되는 맵의 X 좌표는 : {x}, Y 좌표는 : {y}");
                DataManager.instance.mapGrid[0].mapArr[x] = maps;
                DataManager.instance.twoBoolArr[0].boolArr[x] = true;

                DataManager.instance.mapGrid[1].mapArr[y] = maps;
                DataManager.instance.twoBoolArr[1].boolArr[y] = true;

                MapArrTwo mapArrTwo = new MapArrTwo(DataManager.instance.mapGrid);
                BoolArrTwo boolArrTwo = new BoolArrTwo(DataManager.instance.twoBoolArr);
                DataManager.instance.TwoSave(mapArrTwo);
                DataManager.instance.TwoSave(null, boolArrTwo);
                RoomCount++;
            }
        }
    }

    int number = 1;

    void InputShopMap(Map[,] map, Map _map)
    {
        while (true)
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
                    GameObject spawnMap = Instantiate(shop, _map.SetPos(x, y), Quaternion.identity);

                    GameObject spawnMiniMap = Instantiate(shopMinimap, minimap.transform);

                    spawnMiniMap.transform.localPosition = _map.MiniMapSetPos(x - 5, y - 6);

                    spawnMap.name = $"Shop{number}";
                    number++;

                    map[x, y] = _map;
                    MapShopAndBoss(x, y);
                    break;
                }
            }
        }
    }
    void InputBossMap(Map[,] map, Map _map)
    {
        while (true)
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
                    GameObject spawnMap = Instantiate(bossMap, _map.SetPos(x, y), Quaternion.identity);

                    GameObject spawnMiniMap = Instantiate(bossMinimap, minimap.transform);

                    spawnMiniMap.transform.localPosition = _map.MiniMapSetPos(x - 5, y - 6);


                    spawnMap.name = $"Boss";

                    map[x, y] = _map;
                    MapShopAndBoss(x, y);
                    break;
                }
            }
        }
    }

    int roomSaveNumber = 0;
    void mapGirdSave(int own, int two)
    {
        try
        {
            DataManager.instance.nowPlayer.mapGrid[roomSaveNumber] = own;
            roomSaveNumber++;
            DataManager.instance.nowPlayer.mapGrid[roomSaveNumber] = two;
            /*if (number <= 21)
            {
                number++;
            }*/
            roomSaveNumber++;
            DataManager.instance.SaveData();
        }
        catch
        {
            Debug.Log($"현재 맵 그리드 숫자 {roomSaveNumber}, 넣으려는 숫자 {own}, {two}");
        }
    }

    int roomShopAndBoss;
    void MapShopAndBoss(int own, int two)   //여기에다가 보스랑 저거 뭐냐 상점 위치저장할거임.
    {
        DataManager.instance.nowPlayer.mapShopAndBoss[roomShopAndBoss] = own;
        roomShopAndBoss++;
        DataManager.instance.nowPlayer.mapShopAndBoss[roomShopAndBoss] = two;
        roomShopAndBoss++;

        DataManager.instance.SaveData();
    }
    int random = 0;
    public GameObject PopMap()
    {
        random = Random.Range(0, randomMap.Count);
        GameObject returnMap = randomMap[random];
        //Debug.Log(randomMap[random]);
        return returnMap;
    }
}