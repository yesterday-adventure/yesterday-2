using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPotion : ItemSkil
{
    [SerializeField] private int itemMaxColl = 10;
    int[,] randomMap;

    public override bool Skill()
    {
        if (DoorOnOff.Instance.hit != null)
            return false;

        while (true)
        {
            int x = Random.Range(0, 10);
            int y = Random.Range(0, 10);
            Debug.Log(RandomMapSpawn.Instance);
            if (Mathf.Abs(x - DoorOnOff.Instance.x) + Mathf.Abs(y - DoorOnOff.Instance.y) >= 2)
            {
                if (RandomMapSpawn.Instance.mapGrid[x, y] != null)
                {
                    GameObject.Find("Player").transform.position = RandomMapSpawn.Instance.maps.SetPos(x, y);
                    break;
                }
            }
        }
        maxColl = itemMaxColl;
        return true;
    }
}
