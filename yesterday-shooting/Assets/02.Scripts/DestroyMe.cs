using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyHp>().hp -= 10;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            //DataManager.instance.nowPlayer.playerHp -= 1;
            collision.GetComponent<PlayerHp>().OnDamage(()=>{});
            Debug.Log("플레이어에게 닿음");
        }

        gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
    }

    public void DestroyMeMethod()
    {
        Destroy(gameObject);
    }
}
