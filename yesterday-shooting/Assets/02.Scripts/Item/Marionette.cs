using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marionette : ItemSkil
{
    BulletMove bulletMove = new BulletMove();
    BulletInfo bulletInfo = new BulletInfo();

    [SerializeField] private GameObject player = null;
    private float tlqkf = 180;
    private Vector2 playerrota = new Vector2();
    public override void Skil()
    {
        if (curColl > maxColl) {
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
            //플레이어의 y축을 180도 돌려 반전시킨다.
            bulletInfo.Damage += 5;
            //이동키와 공격키가 반전되고 공격력이 5증가
        }
    }
}
