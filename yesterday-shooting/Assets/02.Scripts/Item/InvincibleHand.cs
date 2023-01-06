using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvincibleHand : ItemSkill
{
    [SerializeField] private int itemMaxColl = 10;

    private GameObject player;

    private Vector2 playerPos;

    //무적인건 ~playerHp/OnDamage 조건문에 붙여둠 ㅇㅇ

    //public bool isSkil = false; //스킬이 돌아가는 중인지 구분하는

    // private void Update() {
    //     if (isSkil) {
    //         player.transform.position = playerPos; //3초가 안 지났다면 계속 고정 위치값 때려박아주기
    //     }
    // }
    public override bool Skill()
    {
        maxCool = itemMaxColl; //이 아이템의 최대 쿨타임 수를 정한다.

        //player = GameObject.Find("Player");
        
        //playerPos = player.transform.position; //사용 시 플레이어 위치 받아오는
        //StartCoroutine(SkillTime());
        //isSkil = true;
        PlayerItem.Instance.useInvincibleHand = true;
        PlayerManager.instance.delayTime = 0f;
        return true;
    }

    // IEnumerator SkillTime() { //3초 동안 굴러가는,,
    //     isSkil = true;
    //     yield return new WaitForSeconds(3);
    //     isSkil=  false;
    // }
}
