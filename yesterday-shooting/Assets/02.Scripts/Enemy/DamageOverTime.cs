using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    public void Dot(float damage, float loopTime, float tick)
    {
        StartCoroutine(CoDot(damage,loopTime,tick));
    }
    public IEnumerator CoDot(float damage, float loopTime, float tick)
    {
        Debug.Log("후후 공격시작이닷");
        EnemyHp enemyHp = GetComponent<EnemyHp>();
        for (int i = 0; i < loopTime; i++)
        {
            enemyHp.OnDamage(() => { }, damage);
            yield return new WaitForSeconds(tick);
            Debug.Log("틱이닷!!!!아얏!!"); //?
        }
    }
}
