using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLAPattern : MonoBehaviour
{
    public GameObject EnemyBullet = null;
    [SerializeField] EnemyBulletDir.FireDir firDir;
    [SerializeField] public float delay = 0f;
    GameEffectSoundManager effectSound;

    private void Start()
    {
        effectSound = FindObjectOfType<GameEffectSoundManager>();
    }

    void OnEnable()
    {
        StartCoroutine("Attack");
    }

    IEnumerator Attack()
    {
        while(DataManager.instance.nowPlayer.playerHp > 0)
        {
            yield return new WaitForSeconds(delay);
            
            GameObject obj = PoolManager.Instance.Pop(EnemyBullet,transform.position,Quaternion.identity);
            effectSound.MonsterAtteck();
            obj.GetComponent<EnemyBulletMove>().set(firDir);
        }
    }
}
