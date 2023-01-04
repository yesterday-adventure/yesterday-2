using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RustyRazorBlade : ItemSkill
{
    [SerializeField] private int itemMaxColl = 5;

    EnemyHp enemyHp;
    DamageOverTime damageOverTime;
    private bool isSkill;
    public override bool Skill()
    {
        maxCool = itemMaxColl; //이 아이템의 최대 쿨타임 수를 정한다.

        enemyHp = FindObjectOfType<EnemyHp>();
        damageOverTime = FindObjectOfType<DamageOverTime>();

        //에너미를 타격했다면 도트뎀을 2초 동안 1초 간격으로 1만큼 준다
        if (enemyHp.isAttack) damageOverTime.Dot(1, 2, 1);
        return true;
    }
}
