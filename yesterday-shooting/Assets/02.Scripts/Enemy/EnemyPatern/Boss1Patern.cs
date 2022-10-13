using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Patern : MonoBehaviour
{
    private int random = 0;

    [SerializeField] SLAPattern attackSpeed;
    [SerializeField] GameObject monster1 = null;
    [SerializeField] GameObject monster2 = null;
    [SerializeField] EnemyHp enemyHp;

    public GameObject EnemyBullet = null;
    public GameObject player = null;
    private float playerz;

    public GameObject healing;
    private void OnEnable()
    {
        player = GameObject.Find("Player");
        Invoke("A",1f);
    }

    private void A()
    {
        StartCoroutine("PatternAttack");
        PoolManager.Instance.Pop(EnemyBullet,transform.position,Quaternion.identity);
    }
    IEnumerator PatternAttack()
    {
        while (true)
        {
            random = Random.Range(1, 6);
            switch (random)
            {
                case 1:
                    Instantiate(monster1, transform.position, Quaternion.identity);
                    Instantiate(monster2, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(3f);
                    break;

                case 2:
                    attackSpeed.delay = 0.05f;
                    yield return new WaitForSeconds(3f);
                    attackSpeed.delay = 0.5f;
                    break;

                case 3:
                    int l = 0;
                    if(player.transform.position.y > 0)
                    {
                        l = -30;
                        playerz = -player.transform.position.x;
                    }
                    else
                    {
                        l = 150;
                        playerz = player.transform.position.x;
                    }
                    for (int i = l; i < l + 60; i = i+2)
                    {
                        PoolManager.Instance.Pop(EnemyBullet,transform.position,Quaternion.Euler(0,0,playerz * 10 + i));
                        yield return new WaitForSeconds(0.01f);
                    }
                    yield return new WaitForSeconds(3f);
                    break;

                case 4:
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            PoolManager.Instance.Pop(EnemyBullet,transform.position, Quaternion.Euler(0, 0, j * 36));
                        }
                        yield return new WaitForSeconds(0.2f);
                    }
                    yield return new WaitForSeconds(3f);
                    break;

                case 5:
                    enemyHp.hp += 50;
                    Instantiate(healing,new Vector3(transform.position.x +1,transform.position.y+1,0),Quaternion.identity);
                    Instantiate(healing,new Vector3(transform.position.x -1,transform.position.y-1,0),Quaternion.identity);
                    yield return new WaitForSeconds(3f);
                    break;

                default:
                    yield return null;
                    break;
            }
        }
    }
}
