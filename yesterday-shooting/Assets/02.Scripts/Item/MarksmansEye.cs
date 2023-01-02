using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarksmansEye : ItemSkill
{
    EnemyHp enemyHp;

    private GameObject _attackEnemy;

    public override bool Skill()
    {
        //공격했다면 데미지 20 때려박기 (기본 에너미의 경우 즉사해벌ㄹ임;)
        if (enemyHp.isAttack) enemyHp.OnDamage(() => { }, 20);
        return true;
    }
}
