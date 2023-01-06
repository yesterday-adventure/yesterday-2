using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEditor;
using Unity.Rendering.HybridV2;
using UnityEngine.UI;

public class PlayerHp : MonoBehaviour
{
    //public int hp = 5;
    [SerializeField] Light2D playerLight;
    public float shieldTime = 1; // 무적시간
    [SerializeField] SpriteRenderer sR;

    IronArmor ironArmor;
    InvincibleHand invincibleHand;
    Camera camera1;

    [SerializeField] private GameObject[] active;

    private bool isdie = true;
    int nowHp;

    [SerializeField] private GameObject deathParticle;

    //private bool isInvincibleHand = false; //invin~ 아이템을 플레이어가 가지고 있는지 없는지 판단할 변수

    // private void Update() {
    //     if (GameObject.Find("Player/InvincibleHand")) isInvincibleHand = true; //플레이어 아래 이 아이템이 있다면,,
    // }

    private void Awake()
    {
        ironArmor = FindObjectOfType<IronArmor>();
        invincibleHand = FindObjectOfType<InvincibleHand>();
        camera1 = GameObject.Find("Main Camera").GetComponent<Camera>();
        nowHp = DataManager.instance.nowPlayer.playerHp;
    }

    private void OnDisable()
    {
        Time.timeScale = 1f;
    }



    public void OnDamage(Action lambda)
    {
        if (PlayerItem.Instance.useIronArmor)
        { //철갑주 아이템을 사용하여 보호막이 있는 경우
            shieldTime = 0;
            PlayerItem.Instance.useIronArmor = false;
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

    IEnumerator StartTimeFrizm()
    {
        //int r = UnityEngine.Random.Range(-5, 5);
        Time.timeScale = 0.5f;
        //camera1.orthographicSize = 3.95f;
        //camera1.transform.rotation = Quaternion.Euler(0, 0, r);

        //camera1.transform.DORotate(new Vector3(0, 0, 0), 0.7f);
        while (Time.timeScale < 1)
        {
            Time.timeScale += 0.01f;
            //camera1.orthographicSize += 0.015f;
            yield return new WaitForSeconds(0.01f);
        }
        yield return null;
    }

    private void HitAnimation()
    {
        if (DataManager.instance.nowPlayer.playerHp > 0)
        {
            StartCoroutine(StartTimeFrizm());
            Sequence seq = DOTween.Sequence();
            seq.Append(sR.DOFade(0, 0.1f));
            seq.Append(sR.DOFade(1, 0.3f));
            seq.Append(sR.DOFade(0, 0.1f));
            seq.Append(sR.DOFade(1, 0.3f));
        }
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
        if (Input.GetKeyDown(KeyCode.L))
            DataManager.instance.nowPlayer.playerHp--;

        if (Input.GetKeyDown(KeyCode.K))
            DataManager.instance.nowPlayer.playerHp++;

        if (DataManager.instance.nowPlayer.playerHp <= 0 && isdie)
        {
            Sequence seq = DOTween.Sequence();
            seq.Append(camera1.transform.DOMove(
            new Vector3(transform.position.x, transform.position.y, camera1.transform.position.z), 4f));
            DieCamera();
        }

        if (shieldTime < 1)
            shieldTime += Time.deltaTime;

        if (nowHp != DataManager.instance.nowPlayer.playerHp)
        {
            Debug.Log("체력달음");
            FindObjectOfType<GameEffectSoundManager>().playerHpDown();
            nowHp = DataManager.instance.nowPlayer.playerHp;
        }
    }

    private void DieCamera()
    {
        Sequence seq = DOTween.Sequence();
        Light2D[] light = FindObjectsOfType<Light2D>();
        foreach (var item in light)
        {
            item.intensity = 0;
        }
        playerLight.intensity = 1f;
        playerLight.pointLightOuterRadius = 10;
        isdie = false;
        seq.PrependCallback(() =>
        {
            for (int i = 0; i < active.Length; i++)
            {
                active[i].SetActive(false);
            }
        })
        .AppendInterval(1f)
        .AppendCallback(() =>
        {
            Instantiate(deathParticle, transform.position, Quaternion.identity);
        }).SetUpdate(false)
        .Append(DOTween.To(() => playerLight.pointLightOuterRadius, x => playerLight.pointLightOuterRadius = x, 2, 2).SetUpdate(false))
        .Join(DOTween.To(() => playerLight.pointLightInnerRadius, x => playerLight.pointLightInnerRadius = x, 2, 2).SetUpdate(false))
        .Join(DOTween.To(() => camera1.orthographicSize, x => camera1.orthographicSize = x, 2, 2).SetUpdate(false))
        .AppendInterval(1).SetUpdate(false)
        .AppendCallback(() =>
        {
            Destroy(gameObject);
            Die();
        });
        //while (camera1.orthographicSize >= 2f)
        //{
        //    camera1.orthographicSize -= 0.01f;
        //    yield return new WaitForSeconds(0.01f);
        //}
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if ((other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet")) && shieldTime >= 1)
        {
            if (invincibleHand != null)
            { //null이 아니라면
                if (!PlayerItem.Instance.useInvincibleHand) { OnDamage(() => { }); } //무적 상태가 아니라면
            }
            else { OnDamage(() => { }); }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet")) && shieldTime >= 1)
        {
            if (invincibleHand != null)
            { //null이 아니라면
                if (!PlayerItem.Instance.useInvincibleHand) { OnDamage(() => { }); } //무적 상태가 아니라면
            }
            else { OnDamage(() => { }); }
        }
    }

    void Die()
    {

        System.IO.File.Delete(DataManager.instance.path + $"{DataManager.instance.nowSlot}");
        System.IO.File.Delete(DataManager.instance.path + $"TwoArr{DataManager.instance.nowSlot}");
        System.IO.File.Delete(DataManager.instance.path + $"TwoArrBool{DataManager.instance.nowSlot}");
        System.IO.File.Delete(DataManager.instance.path + $"AfterData{DataManager.instance.nowSlot}");
        Select.instance.savefile[DataManager.instance.nowSlot] = false;

        //DataManager.instance.DataClear();

        //File.Delete(DataManager.instance.path + DataManager.instance.nowSlot);
        SceneManager.LoadScene("Over");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}