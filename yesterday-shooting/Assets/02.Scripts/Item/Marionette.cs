using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marionette : ItemSkill 
{
    [SerializeField] private int itemMaxColl = 10;
    [SerializeField] private GameObject player = null;
    
    public override bool Skill()
    {
        maxCool = itemMaxColl; //이 아이템의 최대 쿨타임 수를 정한다.
        player = GameObject.Find("Player");
        player.transform.rotation = Quaternion.Euler(0, 180, 0);

        PlayerFire.instance.inputRight = KeyCode.LeftArrow;
        PlayerFire.instance.inputLeft = KeyCode.RightArrow;
        PlayerFire.instance.inputUp = KeyCode.DownArrow;
        PlayerFire.instance.inputDown = KeyCode.UpArrow;

        PlayerManager.instance.moveChange = -1;
        //플레이어의 y축을 180도 돌려 반전시킨다. = 이동, 공격키 반전
        PlayerItem.Instance.plusMarionette += 5;
        //공격력이 5증가
        StartCoroutine(Use(15f));
        return true;
    }

    IEnumerator Use(float time)
    {
        float time1 = 0f;
        if(time1 < time)
        {
            time1 += Time.deltaTime;
            yield return null;
        }
        PlayerItem.Instance.plusMarionette -= 5;
    }
}
