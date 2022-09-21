using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{
    [SerializeField] GameObject room;
    [SerializeField] int roomNumber;

    private void Update()
    {
        Collider2D hitPlayer = Physics2D.OverlapBox(transform.position, new Vector2(17f, 9f), 0, 1 << 8);
        if(hitPlayer != null && DataManager.instance.nowPlayer.roomClear[roomNumber] == false)
        {
            room.SetActive(true);
        }
    }

}
