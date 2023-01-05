using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class EnemyHp : MonoBehaviour, IDamageable
{
    [SerializeField] public float hp;
    private SpriteRenderer _renderer;

    private bool _isAttack;

    public bool isAttack {
        get { return _isAttack; }
        set { _isAttack = value; }
    }

    [SerializeField] private GameObject bomb = null;

    [SerializeField] private GameObject coin = null;

    private int ran;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    
    public void OnDamage(Action lambda, float damage)
    {
        _isAttack = true;
        hp -= damage;
        //Debug.Log($"damage : {damage} , hp : {hp}");

        if (hp > 0)
        {
            _renderer.DOColor(Color.red, 0.2f);
            Invoke("WhiteColorChange", 0.2f);
        }
    }

    private void WhiteColorChange()
    {
        _renderer.DOColor(Color.white, 0.1f);
    }

    private void Update()
    {
        if (hp <= 0)
        {
            Die();//여기에 죽는 애니메이션
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            if(PlayerItem.Instance.useMarksmansEye)
            {
                OnDamage(()=>{}, 20f);
                PlayerItem.Instance.useMarksmansEye = false;
            }
            else
            {
                OnDamage(() => { }, other.GetComponent<BulletInfo>().Damage);
            }
        }
    }

    GameEffectSoundManager effectSound;

    private void Start()
    {
        effectSound = FindObjectOfType<GameEffectSoundManager>();
    }

    void Die()
    {
        PlayerItem.Instance.cool--;
        effectSound.MonsterDie();
        Destroy(this.gameObject);

        SpawnCoin();
        SpawnBomb();
    }

    void SpawnCoin(){
        ran = UnityEngine.Random.Range(1, 3); //이거 유니티엔진이랑 시스템 사이에서 모호하대서 걍 때려박음
        
        for (int i = 0; i < ran; i++) { //코인 생성, 반반 확률로 1개나 2개 얻기 ㄱㄴ
            Instantiate(coin, gameObject.transform.position, Quaternion.identity);
            //DataManager.instance.afterData.dropCoin.Add(gameObject.transform.position);
            ran = 0;
        }
    }

    void SpawnBomb() {
        ran = UnityEngine.Random.Range(0, 101);

        if (ran <= 25) { //폭탄 생성, 25 확률로 1개 줌 ㅎㅎ
            Instantiate(bomb, gameObject.transform.position, Quaternion.identity);
            //DataManager.instance.afterData.dropBomb.Add(gameObject.transform.position);
            ran = 0;
        }
    }
}