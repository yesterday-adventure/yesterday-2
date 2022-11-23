using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEffect : MonoBehaviour
{
    [SerializeField] float splashRange;
    [SerializeField] float splashDamage;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerManager.instance.player.transform.position = transform.position;
            PoolManager.Instance.Push(gameObject);
            Debug.Log("ThunderBulletEffect");
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, splashRange, Define.monster);
            foreach (Collider2D item in hit)
            {
                item.gameObject.GetComponent<EnemyHp>().OnDamage(() => { }, splashDamage);
                //PoolManager.Instance.Pop(¿Ã∆Â∆Æ «¡∏Æ∆’,item.transform.position,Quaternion.identity);
            }
        }
    }
}
