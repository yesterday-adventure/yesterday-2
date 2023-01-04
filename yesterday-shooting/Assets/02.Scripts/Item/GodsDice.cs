using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodsDice : ItemSkill
{
    private EnemyHp[] enemyHps;
    [SerializeField] private int itemMaxColl = 20;
    private int rand = 0;
    public override bool Skill()
    {
        if(DoorOnOff.Instance.hit != null)
        {
            return false;
        }
        else
        {
            maxCool = itemMaxColl;
            rand = Random.Range(1, 101);
            if (rand <= 20) 
            {
                Debug.Log("20%");
                PlayerItem.Instance.useGodsDice = true;
            }
            else
                Debug.Log("80%");

            return true;
        }
    }
}
