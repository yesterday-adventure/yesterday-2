using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marionette : ItemSkill 
{
    [SerializeField] private int itemMaxColl = 10;
    BulletMove bulletMove;
    BulletInfo bulletInfo;

    [SerializeField] private GameObject player = null;
    public override bool Skill()
    {
        maxCool = itemMaxColl; //이 아이템의 최대 쿨타임 수를 정한다.

        player.transform.rotation = Quaternion.Euler(0, 180, 0);
        //플레이어의 y축을 180도 돌려 반전시킨다. = 이동, 공격키 반전
        bulletInfo.Damage += 5;
        //공격력이 5증가
        
        return true;
    }
}
