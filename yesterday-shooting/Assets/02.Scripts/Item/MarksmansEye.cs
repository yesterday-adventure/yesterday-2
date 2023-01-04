using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarksmansEye : ItemSkill
{
    [SerializeField] private int itemMaxColl = 5;

    EnemyHp enemyHp;

    private GameObject _attackEnemy;

    public override bool Skill()
    {
        maxCool = itemMaxColl; //이 아이템의 최대 쿨타임 수를 정한다.

        enemyHp = FindObjectOfType<EnemyHp>();

        //공격했다면 데미지 20 때려박기 (기본 에너미의 경우 즉사해벌ㄹ임;, 보스의 경우 20만 주기)
        if (enemyHp.isAttack) enemyHp.OnDamage(() => { }, 20);
        return true;
    }
}
