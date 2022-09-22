using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapSpawn : MonoBehaviour
{
    [SerializeField] Map maps;
    public Map[,] mapGrid = null;
    [SerializeField] GameObject[] randomMap;

    private int xIndex = 9;
    private int yIndex = 10;

    private int RoomCount = 0;
    private int NearRoomCount = 0;

    [SerializeField] int maxRoomCount;
    private void Awake()
    {
        mapGrid = null;
    }
    void Start()
    {
        mapGrid = new Map[xIndex + 1, yIndex + 1];
        InputStartMap(mapGrid, maps);
        while (RoomCount < maxRoomCount)
        {
            RandomSpawn(mapGrid, maps);
        }
    }

    void InputStartMap(Map[,] map, Map _map)
    {
        //GameObject spawnMap = Instantiate(PopMap(), _map.SetPos(5, 6), Quaternion.identity);
        //spawnMap.name = "Start";
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
                spawnMap.name = spawnMap.name.Replace("(Clone)", "");
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