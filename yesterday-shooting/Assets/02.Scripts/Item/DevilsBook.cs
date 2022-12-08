using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilsBook : ItemSkil
{
    [SerializeField] private int itemMaxColl = 10;
    PlayerData playerData;
    BulletInfo bulletInfo;
    public override void Skil() {
        maxColl = itemMaxColl; //이 아이템의 최대 쿨타임 수를 정한다.
        //curColl = EnemyHP 스크립트에서 에너미가 죽을 때 마다 ++ 해준 변수를 넣어준다.
        if (curColl > maxColl) {
            playerData.playerHp -= 1;
            //HP - 1
            bulletInfo.Damage += 3;
            //공격력 3 증가
        }
    }
}
