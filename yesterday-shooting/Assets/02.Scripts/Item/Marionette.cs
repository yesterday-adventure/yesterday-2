using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marionette : ItemSkil
{
    [SerializeField] private int itemMaxColl = 10;
    BulletMove bulletMove;
    BulletInfo bulletInfo;

    [SerializeField] private GameObject player = null;
    private float tlqkf = 180;
    private Vector2 playerrota = new Vector2();
    public override void Skil() {
            maxColl = itemMaxColl; //이 아이템의 최대 쿨타임 수를 정한다.
            //curColl = EnemyHP 스크립트에서 에너미가 죽을 때 마다 ++ 해준 변수를 넣어준다.
        if (curColl > maxColl) {

            player.transform.rotation = Quaternion.Euler(0, 180, 0);
            //플레이어의 y축을 180도 돌려 반전시킨다.
            bulletInfo.Damage += 5;
            //이동키와 공격키가 반전되고 공격력이 5증가
        }
    }
}
