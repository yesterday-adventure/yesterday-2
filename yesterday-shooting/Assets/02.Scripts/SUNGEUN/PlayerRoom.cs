using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoom : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 플레이어 이동 방 저장은 죽어라 얍!
        if (collision.tag == "room0") DataManager.instance.nowPlayer.playerRoom = 0;
        if (collision.tag == "room1") DataManager.instance.nowPlayer.playerRoom = 1;
        if (collision.tag == "room2") DataManager.instance.nowPlayer.playerRoom = 2;
        if (collision.tag == "room3") DataManager.instance.nowPlayer.playerRoom = 3;
        if (collision.tag == "room4") DataManager.instance.nowPlayer.playerRoom = 4;
        if (collision.tag == "room5") DataManager.instance.nowPlayer.playerRoom = 5;
        if (collision.tag == "room6") DataManager.instance.nowPlayer.playerRoom = 6;
        if (collision.tag == "room7") DataManager.instance.nowPlayer.playerRoom = 7;
        if (collision.tag == "room8") DataManager.instance.nowPlayer.playerRoom = 8;
        if (collision.tag == "room9") DataManager.instance.nowPlayer.playerRoom = 9;
        if (collision.tag == "room10") DataManager.instance.nowPlayer.playerRoom = 10;
        if (collision.tag == "room11") DataManager.instance.nowPlayer.playerRoom = 11;
        if (collision.tag == "room12") DataManager.instance.nowPlayer.playerRoom = 12;

        if (collision.tag == "Up")
        {
            DataManager.instance.nowPlayer.playerDirection = 1;
            Debug.Log("tlqkf");
        }
        if (collision.tag == "Down") DataManager.instance.nowPlayer.playerDirection = 2;
        if (collision.tag == "Right") DataManager.instance.nowPlayer.playerDirection = 3;
        if (collision.tag == "Left") DataManager.instance.nowPlayer.playerDirection = 4;
        if (collision.tag == "Center") DataManager.instance.nowPlayer.playerDirection = 5;
        DataManager.instance.SaveData();
    }
}
