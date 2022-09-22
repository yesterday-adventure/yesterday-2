using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMapSpawn : MonoBehaviour
{
    [SerializeField] Map maps;
    Map[,] mapgrid = null;
    [SerializeField] GameObject[] randomMap;

    private int xindex = 9;
    private int yindex = 10;

    private int checkroom = 0;
    private int checknearroom = 0;

    [SerializeField] int createRoom;
    private void Awake()
    {
        mapgrid = null;
    }
    void Start()
    {
        mapgrid = new Map[xindex + 1, yindex + 1];
        InputStartMap(mapgrid, maps);
        while (checkroom < createRoom)
        {
            RandomSpawn(mapgrid, maps);
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
        checknearroom = 0;
        int x = Random.Range(1, xindex);
        int y = Random.Range(1, yindex);
        if (map[x, y] == null)
        {
            if (map[x + 1, y] != null)
                checknearroom++;
            if (map[x - 1, y] != null)
                checknearroom++;
            if (map[x, y + 1] != null)
                checknearroom++;
            if (map[x, y - 1] != null)
                checknearroom++;

            if (checknearroom == 1)
            {
                GameObject spawnMap = Instantiate(PopMap(), _map.SetPos(x, y), Quaternion.identity);
                spawnMap.name = spawnMap.name.Replace("(Clone)", "");
                map[x, y] = _map;
                Debug.Log($"x : {x} y : {y}");
                checkroom++;
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