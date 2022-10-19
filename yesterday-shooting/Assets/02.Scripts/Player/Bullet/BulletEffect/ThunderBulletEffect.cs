using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderBulletEffect : MonoBehaviour
{
    [SerializeField] float effectRadius;
    [SerializeField] float thunderEffectDamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("ThunderBulletEffect");
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, effectRadius, Define.monster);
            foreach (Collider2D item in hit)
            {
                item.gameObject.GetComponent<EnemyHp>().OnDamage(() => { }, thunderEffectDamage);
                //PoolManager.Instance.Pop(¿Ã∆Â∆Æ «¡∏Æ∆’,item.transform.position,Quaternion.identity);
            }
        }
    }
}
