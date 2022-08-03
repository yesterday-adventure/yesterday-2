using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurstPattern : MonoBehaviour
{
    public GameObject EnemyBullet = null;

    private void OnDisable()
    {
        GameObject obj = PoolManager.Instance.Pop(EnemyBullet,transform.position,Quaternion.identity);
        obj.GetComponent<EnemyBulletMove>().set(EnemyBulletDir.FireDir.up);

        GameObject obj1 = PoolManager.Instance.Pop(EnemyBullet,transform.position,Quaternion.identity);
        obj1.GetComponent<EnemyBulletMove>().set(EnemyBulletDir.FireDir.down);
        
        GameObject obj2 = PoolManager.Instance.Pop(EnemyBullet,transform.position,Quaternion.identity);
        obj2.GetComponent<EnemyBulletMove>().set(EnemyBulletDir.FireDir.right);

        GameObject obj3 = PoolManager.Instance.Pop(EnemyBullet,transform.position,Quaternion.identity);
        obj3.GetComponent<EnemyBulletMove>().set(EnemyBulletDir.FireDir.left);
    }
}
