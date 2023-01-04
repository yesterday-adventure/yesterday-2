using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    //public int hp = 5;
    public float shieldTime = 1; // 무적시간
    [SerializeField] SpriteRenderer sR;

    IronArmor ironArmor;
    InvincibleHand invincibleHand;

    //private bool isInvincibleHand = false; //invin~ 아이템을 플레이어가 가지고 있는지 없는지 판단할 변수

    // private void Update() {
    //     if (GameObject.Find("Player/InvincibleHand")) isInvincibleHand = true; //플레이어 아래 이 아이템이 있다면,,
    // }

    private void Awake() {
        ironArmor = FindObjectOfType<IronArmor>();
        invincibleHand = FindObjectOfType<InvincibleHand>();
    }

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
        if ((other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet")) && shieldTime >= 1) {
            if (invincibleHand) { //null이 아니라면
                if (!invincibleHand.isSkil) { OnDamage(() => { }); } //무적 상태가 아니라면
            }
            else { OnDamage(() => { }); }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet")) && shieldTime >= 1) {
            if (invincibleHand) { //null이 아니라면
                if (!invincibleHand.isSkil) { OnDamage(() => { }); } //무적 상태가 아니라면
            }
            else { OnDamage(() => { }); }
        }
    }

    void Die()
    {
        Destroy(gameObject);//플레이어 죽는 애니메션

        System.IO.File.Delete(DataManager.instance.path + $"{DataManager.instance.nowSlot}");
        System.IO.File.Delete(DataManager.instance.path + $"TwoArr{DataManager.instance.nowSlot}");
        System.IO.File.Delete(DataManager.instance.path + $"TwoArrBool{DataManager.instance.nowSlot}");
        Select.instance.savefile[DataManager.instance.nowSlot] = false;

        //DataManager.instance.DataClear();

        //File.Delete(DataManager.instance.path + DataManager.instance.nowSlot);
        SceneManager.LoadScene("Over");
    }
}