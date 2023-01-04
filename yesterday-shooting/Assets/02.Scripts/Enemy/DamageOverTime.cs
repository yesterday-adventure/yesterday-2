using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{

    public IEnumerator Dot(float damage, float loopTime, float tick)
    {
        EnemyHp enemyHp = GetComponent<EnemyHp>();
        for (int i = 0; i < loopTime; i++)
        {
            enemyHp.OnDamage(() => { }, damage);
            yield return new WaitForSeconds(tick);
        }
    }
}
