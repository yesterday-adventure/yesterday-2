using System.Collections;
using UnityEngine;

public class DamageOverTime : MonoBehaviour
{
    public void Dot(float damage, float loopTime, float tick)
    {
        if (gameObject.tag == "Boss")
        {
            StartCoroutine(BossDot(damage, loopTime, tick));
        }
        else
        {
            StartCoroutine(CoDot(damage, loopTime, tick));
        }
    }

    private IEnumerator CoDot(float damage, float loopTime, float tick)
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

    private IEnumerator BossDot(float damage, float loopTime, float tick)
    {
        Debug.Log("후후 공격시작이닷");
        Stage1_1Boss bosshp = GetComponent<Stage1_1Boss>();
        for (int i = 0; i < loopTime; i++)
        {
            bosshp.HP -= damage;
            yield return new WaitForSeconds(tick);
            Debug.Log("틱이닷!!!!아얏!!"); //?
        }
    }

}
