using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using System.IO;
using DG.Tweening;

public class PlayerHp : MonoBehaviour
{
    //public int hp = 5;
    public float shieldTime = 1; // 무적시간
    [SerializeField] SpriteRenderer sR;

    IronArmor ironArmor;
    InvincibleHand invincibleHand;

    public void OnDamage(Action lambda)
    {
        if (ironArmor != null)
        {

            if (ironArmor.shield)
            { //철갑주 아이템을 사용하여 보호막이 있는 경우
                ironArmor.shield = false;
            }
            else
            { //없는 경우
                shieldTime = 0;
                //hp--;
                DataManager.instance.nowPlayer.playerHp--;
                //StartCoroutine(TwinkeON());
                HitAnimation();
                lambda?.Invoke();
            }
        }
        else
        { //없는 경우
            shieldTime = 0;
            //hp--;
            DataManager.instance.nowPlayer.playerHp--;
            //StartCoroutine(TwinkeON());
            HitAnimation();
            lambda?.Invoke();
        }
    }

    private void HitAnimation()
    {
        Sequence seq = DOTween.Sequence();
        seq.Append(sR.DOFade(0, 0.1f));
        seq.Append(sR.DOFade(1, 0.3f));
    }
    //IEnumerator TwinkeON()
    //{
    //    for (int i = 0; i < 2; i++)
    //    {

    //        yield return StartCoroutine(Fade(1, 0));
    //        yield return StartCoroutine(Fade(0, 1));
    //    }
    //}

    //IEnumerator Fade(float start, float end)
    //{
    //    float currentTime = 0;
    //    float percent = 0;
    //    while (percent < 1)
    //    {
    //        currentTime += Time.deltaTime;
    //        percent = currentTime / 0.1f;

    //        Color color = sR.color;
    //        color.a = Mathf.Lerp(start, end, percent);
    //        sR.color = color;

    //        yield return null;
    //    }
    //}

    private void Update()
    {

        if (DataManager.instance.nowPlayer.playerHp <= 0)
        {
            Die();//여기에 죽는 애니메이션
        }

        if (shieldTime < 1)
            shieldTime += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet")) && shieldTime >= 1 && !invincibleHand.isSkil)
            OnDamage(() => { });
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet")) && shieldTime >= 1 && !invincibleHand.isSkil)
            OnDamage(() => { });
    }

    void Die()
    {
        Destroy(gameObject);//플레이어 죽는 애니메션
        System.IO.File.Delete(DataManager.instance.path + DataManager.instance.nowSlot);
        SceneManager.LoadScene("Over");
    }
}