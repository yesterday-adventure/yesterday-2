using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLAPattern : MonoBehaviour
{
    public GameObject EnemyBullet = null;
    [SerializeField] EnemyBulletDir.FireDir firDir;
    void OnEnable()
    {
        StartCoroutine("Attack");
    }

    IEnumerator Attack()
    {
        while(true)
        {
            yield return new WaitForSeconds(2f);
            
            GameObject obj = PoolManager.Instance.Pop(EnemyBullet,transform.position,Quaternion.identity);
            obj.GetComponent<EnemyBulletMove>().set(firDir);
        }
    }
}
