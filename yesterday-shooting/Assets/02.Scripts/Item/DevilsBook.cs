using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilsBook : ItemSkil
{
    PlayerData playerData = new PlayerData();
    BulletInfo bulletInfo = new BulletInfo();
    public override void Skil() {
        maxColl = 5;
        if (curColl > maxColl) {
            playerData.playerHp -= 1;
            //HP - 1
            bulletInfo.Damage += 3;
            //공격력 3 증가
        }
    }
}
