using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHp : MonoBehaviour, IDamageable
{
    [SerializeField]public float hp;
    public void OnDamage(Action lambda)
    {
        hp--;
        lambda?.Invoke();
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

    void Die()
    {
        Destroy(gameObject);//나중에 풀메니저로
    }
}