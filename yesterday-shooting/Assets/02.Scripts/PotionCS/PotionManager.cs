using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && this.CompareTag("Potion"))
        {
            if (this.name == "CoolDownPotion")
            {
                if (PlayerItem.Instance.cool == 0)
                    return;
                else
                {
                    ItemNameAnimation.Instance.InitText("Cooldown Potion","Cooldown Reset!");
                    PlayerItem.Instance.cool = 0;
                    Destroy(gameObject);
                }
            }
            else
            {
                if (DataManager.instance.nowPlayer.playerHp == 5)
                    return;
                else
                {
                    ItemNameAnimation.Instance.InitText("Healing Potion","Recover 2 hearts!");
                    DataManager.instance.nowPlayer.playerHp++;
                    if(DataManager.instance.nowPlayer.playerHp != 5)
                        DataManager.instance.nowPlayer.playerHp++;
                    Destroy(gameObject);
                }
            }
        }
    }
}