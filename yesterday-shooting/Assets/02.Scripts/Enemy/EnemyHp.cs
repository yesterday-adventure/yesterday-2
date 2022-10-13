using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;
public class EnemyHp : MonoBehaviour, IDamageable
{
    [SerializeField]public float hp;
    private SpriteRenderer _renderer;
    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }
    public void OnDamage(Action lambda)
    {
        hp--;
        if(hp > 0)
        {
            _renderer.DOColor(Color.red,0.2f);
            Invoke("WhiteColorChange",0.2f);
        }
    }

    private void WhiteColorChange()
    {
        _renderer.DOColor(Color.white,0.1f);
    }

    private void Update()
    {
        if(hp <= 0)
        {
            Die();//여기에 죽는 애니메이션
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PlayerBullet"))
            OnDamage(()=>{});
    }

    GameEffectSoundManager effectSound;

    private void Start()
    {
        effectSound = FindObjectOfType<GameEffectSoundManager>();
    }

    void Die()
    {
        effectSound.MonsterDie();
        Destroy(gameObject);//나중에 풀메니저로
    }
}