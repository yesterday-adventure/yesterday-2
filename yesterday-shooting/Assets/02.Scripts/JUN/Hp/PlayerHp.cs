using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    public int hp = 3;
    public float shieldTime = 1; // 무적시간
    public void OnDamage(Action lambda)
    {
        shieldTime = 0;
        hp--;
        lambda?.Invoke();
        Debug.Log("플레이어 데미지 받음");
    }

    private void Update()
    {
        if(hp <= 0)
        {
            Die();//여기에 죽는 애니메이션
        }

        if(shieldTime < 1)
            shieldTime += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Enemy") && shieldTime >= 1)
            OnDamage(()=>{});
    }

    void Die()
    {
        Destroy(gameObject);//플레이어 죽는 애니메션
        SceneManager.LoadScene("Intro");
    }
}