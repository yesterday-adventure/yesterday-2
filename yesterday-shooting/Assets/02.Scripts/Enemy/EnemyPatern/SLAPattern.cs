using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SLAPattern : MonoBehaviour
{
    public GameObject EnemyBullet = null;
    [SerializeField] EnemyBulletDir.FireDir firDir;
    [SerializeField] public float delay = 0f;
    GameEffectSoundManager effectSound;
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        player = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
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
