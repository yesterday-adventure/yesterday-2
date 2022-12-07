using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JSonIsRoomClear : MonoBehaviour
{
    [SerializeField] int roomNumber;
    /*private void OnEnable()
    {
        Collider2D hitmonster = Physics2D.OverlapBox(transform.position, new Vector2(17f, 9f), 0, 1 << 10);
        Collider2D hitPlayer = Physics2D.OverlapBox(transform.position, new Vector2(17f, 9f), 0, 1 << 8);
        
        if (hitmonster == null || hitPlayer != null)
        {
            DataManager.instance.nowPlayer.roomClear[roomNumber] = true;
        }
    }*/

    private void Update()
    {
        Collider2D hitmonster = Physics2D.OverlapBox(transform.position, new Vector2(17f, 9f), 0, 1 << 10);
        Collider2D hitPlayer = Physics2D.OverlapBox(transform.position, new Vector2(17f, 9f), 0, 1 << 8);

        if (hitmonster == null && hitPlayer != null)
        {
            Debug.Log("방이 클리어 되었다.");
            DataManager.instance.nowPlayer.roomClear[roomNumber - 1] = true;
            DataManager.instance.SaveData();
        }
    }
}
