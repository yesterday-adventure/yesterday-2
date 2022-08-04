using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHp : MonoBehaviour
{
    [SerializeField]PlayerHp playerHp;
    void Update()
    {
        showplayerhp();
    }

    private void showplayerhp()
    {
        switch(playerHp.hp)
        {
            case 4:
                this.transform.GetChild(4).gameObject.SetActive(false);
                break;
            case 3:
                this.transform.GetChild(3).gameObject.SetActive(false);
                break;
            case 2:
                this.transform.GetChild(2).gameObject.SetActive(false);
                break;
            case 1:
                this.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case 0:
                this.transform.GetChild(0).gameObject.SetActive(false);
                break;
        }
    }
}
