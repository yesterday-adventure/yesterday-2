using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPiecesAttachedPattern : MonoBehaviour
{
    public GameObject Piece;
    EnemyHp enemyHp;
    private void Awake()
    {
        enemyHp = GetComponent<EnemyHp>();
    }
    private void OnDisable()
    {
        if(enemyHp.hp <= 0)
        {
            PoolManager.Instance.Pop(Piece,transform.position + new Vector3(Random.Range(0f,1f),Random.Range(0f,1f),0),Quaternion.identity);
            PoolManager.Instance.Pop(Piece,transform.position + new Vector3(Random.Range(0f,-1f),Random.Range(0f,-1f),0),Quaternion.identity);
        }
    }
}
