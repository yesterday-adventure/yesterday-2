using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseNail : ItemSkill
{
    PlayerData playerData;

    Vector2 player;

    Collider2D[] overLapBox;

    private Vector2 size;
    AgentMovement movement = null;
    public override bool Skill()
    {
        playerData.playerHp -= 1; //체력을 한 칸 잃는다.
        //오버랩박스 그리기
        //그린애들 찾아다가 스피드 -2
        
        overLapBox = Physics2D.OverlapBoxAll(player, size, 0, 1<<10);

        foreach(var arr in overLapBox){
            if (arr.transform.TryGetComponent(out movement))
            movement.Speed -=2;
            movement = null;
        }

        return true;
    }
}
