using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godsdice : ItemSkil
{
    private int rand = 0;
    public override void Skil()
    {
        rand = Random.Range(1, 100);
        if (rand <= 20) { //20%의 확률로
            //Room 프리팹을 생성하지 않는다.
            //보스방에선 사용이 불가능하다.
        }
    }
}
