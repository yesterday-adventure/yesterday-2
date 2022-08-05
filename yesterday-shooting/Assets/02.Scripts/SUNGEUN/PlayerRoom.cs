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
            Debug.Log("6");
        }
        if (collision.tag == "room7")
        {
            DataManager.instance.nowPlayer.playerRoom = 7;
            DataManager.instance.SaveData();
        }
        if (collision.tag == "room8")
        {
            DataManager.instance.nowPlayer.playerRoom = 8;
            DataManager.instance.SaveData();
        }
        if (collision.tag == "room9")
        {
            DataManager.instance.nowPlayer.playerRoom = 9;
            DataManager.instance.SaveData();
        }
        if (collision.tag == "room10")
        {
            DataManager.instance.nowPlayer.playerRoom = 10;
            DataManager.instance.SaveData();
        }
        if (collision.tag == "room11")
        {
            DataManager.instance.nowPlayer.playerRoom = 11;
            DataManager.instance.SaveData();
        }
        if (collision.tag == "room12")
        {
            DataManager.instance.nowPlayer.playerRoom = 12;
            DataManager.instance.SaveData();
        }
        if (collision.tag == "room13")
        {
            DataManager.instance.nowPlayer.playerRoom = 13;
            DataManager.instance.SaveData();
        }
        if (collision.tag == "room14")
        {
            DataManager.instance.nowPlayer.playerRoom = 14;
            DataManager.instance.SaveData();
        }
    }
}
