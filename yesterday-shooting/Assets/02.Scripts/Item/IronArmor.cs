using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IronArmor : ItemSkill
{
    [SerializeField] private int itemMaxColl = 5;
    
    public override bool Skill()
    {
        if(PlayerItem.Instance.useIronArmor)
            return false;

        maxCool = itemMaxColl; //이 아이템의 최대 쿨타임 수를 정한다.

        //PlayerFire.instance.delay -= 0.3f;
        //공격속도가 0.3초 감소
        PlayerItem.Instance.useIronArmor = true;
        //보호막을 생성한다 ~PlayerHp/OnDamage 메서드에 적용해둠
        
        //공격속도가 0.3 감소하고 한 번의 공격을 막아주는 방어막이 생긴다.
        return true;
    }
}
