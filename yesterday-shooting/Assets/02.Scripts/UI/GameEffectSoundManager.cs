using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEffectSoundManager : MonoBehaviour
{
    [SerializeField] AudioSource playerAtteck, monsterDie, monsterAtteck, playerHit;

    private void Update()
    {
        playerAtteck.volume = DataManager.instance.nowOption.ButtonClickSound;
        monsterDie.volume = DataManager.instance.nowOption.ButtonClickSound;
        monsterAtteck.volume = DataManager.instance.nowOption.ButtonClickSound;
    }

    public void PlayerAtteck()
    {
        playerAtteck.Play();
    }

    public void MonsterAtteck()
    {
        monsterAtteck.Play();
    }

    public void MonsterDie()
    {
        monsterDie.Play();
    }

    public void playerHpDown()
    {
        playerHit.Play();
    }
}
