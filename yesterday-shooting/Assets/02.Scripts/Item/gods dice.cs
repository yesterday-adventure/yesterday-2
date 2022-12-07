using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class godsdice : ItemSkil
{
    private int rand = 0;
    public override void Skil()
    {
        rand = Random.Range(0, 1);
        if (rand == 0) {
            //몬스터가 0.5배
        }
        else if (rand == 1) {
            //몬스터가 1.5배
        }
        //다음 방에 들어갈 때 몬스터가 0.5배가 되거나 1.5배가 된다.
    }
}
