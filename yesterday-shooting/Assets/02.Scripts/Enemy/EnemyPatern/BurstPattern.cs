using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstPattern : MonoBehaviour
{
    public GameObject EnemyBullet = null;
    public GameObject player;
    SpriteRenderer spriteRenderer;

    private void OnEnable()
    {
        player = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void OnDisable()
    {
        if (player == null)
            return;
            
        GameObject obj = PoolManager.Instance.Pop(EnemyBullet, transform.position, Quaternion.identity);
        obj.GetComponent<EnemyBulletMove>().set(EnemyBulletDir.FireDir.up);

        GameObject obj1 = PoolManager.Instance.Pop(EnemyBullet, transform.position, Quaternion.identity);
        obj1.GetComponent<EnemyBulletMove>().set(EnemyBulletDir.FireDir.down);

        GameObject obj2 = PoolManager.Instance.Pop(EnemyBullet, transform.position, Quaternion.identity);
        obj2.GetComponent<EnemyBulletMove>().set(EnemyBulletDir.FireDir.right);

        GameObject obj3 = PoolManager.Instance.Pop(EnemyBullet, transform.position, Quaternion.identity);
        obj3.GetComponent<EnemyBulletMove>().set(EnemyBulletDir.FireDir.left);
    }

    private void Update()
    {
        if (player == null)
            return;

        if(player.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else if(player.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }
}
