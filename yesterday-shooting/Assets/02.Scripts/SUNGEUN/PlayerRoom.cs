using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "room0")
        {
            DataManager.instance.nowPlayer.playerRoom = 0;
            DataManager.instance.SaveData();
        }
        if (collision.tag == "room1")
        {
            DataManager.instance.nowPlayer.playerRoom = 1;
            DataManager.instance.SaveData();
        }
        if (collision.tag == "room2")
        {
            DataManager.instance.nowPlayer.playerRoom = 2;
            DataManager.instance.SaveData();
        }
        if (collision.tag == "room3")
        {
            DataManager.instance.nowPlayer.playerRoom = 3;
            DataManager.instance.SaveData();
        }
        if (collision.tag == "room4")
        {
            DataManager.instance.nowPlayer.playerRoom = 4;
            DataManager.instance.SaveData();
        }
        if (collision.tag == "room5")
        {
            DataManager.instance.nowPlayer.playerRoom = 5;
            DataManager.instance.SaveData();
        }
        if (collision.tag == "room6")
        {
            DataManager.instance.nowPlayer.playerRoom = 6;
            DataManager.instance.SaveData();
        }
    }
}
