using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerHp : MonoBehaviour
{
    //public int hp = 5;
    public float shieldTime = 1; // 무적시간
    public void OnDamage(Action lambda)
    {
        shieldTime = 0;
        //hp--;
        DataManager.instance.nowPlayer.playerHp--;
        lambda?.Invoke();
    }

    private void Update()
    {
        /*if(hp <= 0)
        {
            Die();//여기에 죽는 애니메이션
        }*/

        if (DataManager.instance.nowPlayer.playerHp <= 0)
        {
            Die();//여기에 죽는 애니메이션
        }

        if (shieldTime < 1)
            shieldTime += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if((other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet")) && shieldTime >= 1)
            OnDamage(()=>{});
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if((other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet")) && shieldTime >= 1)
            OnDamage(()=>{});
    }

    void Die()
    {
        Destroy(gameObject);//플레이어 죽는 애니메션
        System.IO.File.Delete(DataManager.instance.path + DataManager.instance.nowSlot);
        SceneManager.LoadScene("Intro");
    }
}
