using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPiecesAttachedPattern : MonoBehaviour
{
    public GameObject Piece;
    EnemyHp enemyHp;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        player = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
        enemyHp = GetComponent<EnemyHp>();
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
    private void OnDisable()
    {
        if((enemyHp.hp <= 0) && (enemyHp.hp >= -50))
        {
            PoolManager.Instance.Pop(Piece,transform.position + new Vector3(Random.Range(0f,1f),Random.Range(0f,1f),0),Quaternion.identity);
            PoolManager.Instance.Pop(Piece,transform.position + new Vector3(Random.Range(0f,-1f),Random.Range(0f,-1f),0),Quaternion.identity);
        }
    }
}
