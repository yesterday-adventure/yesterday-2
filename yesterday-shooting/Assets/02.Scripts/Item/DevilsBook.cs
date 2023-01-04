using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevilsBook : ItemSkill
{
    [SerializeField] private int itemMaxColl = 5;

    public override bool Skill()
    {
        maxCool = itemMaxColl; //이 아이템의 최대 쿨타임 수를 정한다.
                               
        DataManager.instance.nowPlayer.playerHp -= 1;
        //HP - 1
        PlayerFire.instance.weapon.GetComponent<BulletInfo>().Damage += 3;
        //공격력 3 증가

        return true;
    }
}
