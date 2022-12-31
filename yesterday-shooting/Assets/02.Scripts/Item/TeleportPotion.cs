using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPotion : ItemSkill
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
            if (Mathf.Abs(x - DoorOnOff.Instance.x) + Mathf.Abs(y - DoorOnOff.Instance.y) >= 2)
            {
                if (RandomMapSpawn.Instance.mapGrid[x, y] != null)
                {
                    int randomValue = Random.Range(0, 4);
                    switch (randomValue)
                    {
                        case 0:
                            GameObject.Find("Player").transform.position = RandomMapSpawn.Instance.maps.SetPos(x, y)
                            + new Vector2(8f, 0);
                            break;

                        case 1:
                            GameObject.Find("Player").transform.position = RandomMapSpawn.Instance.maps.SetPos(x, y)
                            + new Vector2(-8f, 0);
                            break;

                        case 2:
                            GameObject.Find("Player").transform.position = RandomMapSpawn.Instance.maps.SetPos(x, y)
                            + new Vector2(0, 4f);
                            break;

                        case 3:
                            GameObject.Find("Player").transform.position = RandomMapSpawn.Instance.maps.SetPos(x, y)
                            + new Vector2(0, -4f);
                            break;
                    }
                    GameObject.Find("Main Camera").transform.position = RandomMapSpawn.Instance.maps.SetPos(x, y);
                    GameObject.Find("Main Camera").transform.position += new Vector3(0, 0, -10);
                    DoorOnOff.Instance.x = x;
                    DoorOnOff.Instance.y = y;
                    DataManager.instance.nowPlayer.x = x;
                    DataManager.instance.nowPlayer.y = y;
                    break;
                }
            }
        }
        maxColl = itemMaxColl;
        return true;
    }
}
