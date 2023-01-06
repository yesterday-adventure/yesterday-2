using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurseNail : ItemSkill
{
    [SerializeField] private int itemMaxColl = 5;

    private GameObject player;
    private Vector2 size = new Vector2(50, 50);

    Collider2D[] overLapBox;
    AgentMovement movement = null;

    public override bool Skill()
    {
        maxCool = itemMaxColl; //이 아이템의 최대 쿨타임 수를 정한다.

        player = GameObject.Find("Player");

        DataManager.instance.nowPlayer.playerHp -= 1; //체력을 한 칸 잃는다.
        //오버랩박스 그리기
        //그린애들 찾아다가 스피드 -2
        
        overLapBox = Physics2D.OverlapBoxAll(player.transform.position, size, 0, 1<<10); 
        //오버랩 박스를 만들어 그 구간에 들어온 것들의 콜라이더를 가져온다(레이어가 10번인 = 에너미)

        foreach(var arr in overLapBox){ //걸린 콜라이더들을 전부 반복한다
            if (arr.transform.TryGetComponent(out movement)) //만약 그것에 AgentMovement 스크립트가 있다면
            {
                if(movement.Speed >= 2)
                    movement.Speed /= 2; //그 스크립트의 속도를 2만큼 낮춘다
            }
            movement = null; //? 뭔지 모르겠는데 그렇다
        }

        return true;
    }
}
