using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMe : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            GetComponent<EnemyHp>().hp -= 10;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            DataManager.instance.nowPlayer.playerHp -= 1;
            Debug.Log("플레이어에게 닿음");
        }

        gameObject.GetComponent<CircleCollider2D>().isTrigger = false;
    }

    public void DestroyMeMethod()
    {
        Destroy(gameObject);
    }
}
