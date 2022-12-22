using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{
    [SerializeField] GameObject room;

    public int roomNumber;

    private void Update()
    {
        Collider2D hitPlayer = Physics2D.OverlapBox(transform.position, new Vector2(17f, 9f), 0, 1 << 8);

        if(hitPlayer != null && !DataManager.instance.nowPlayer.roomClear[roomNumber - 1])
        {
            GameManager.Instance.MapTrm = GetComponentInChildren<Grid>().transform;
            if(MapManager.Instance != null)
                MapManager.Instance.Init(GameManager.Instance.MapTrm);
            room.SetActive(true);
            if(PlayerItem.Instance.useGodsDice)
            {
                Debug.Log("사용");
                foreach (EnemyHp enemyHp in transform.GetChild(0).GetComponentsInChildren<EnemyHp>())
                {
                    enemyHp.hp = 0;
                    Debug.Log("삭-제");
                }
                PlayerItem.Instance.useGodsDice = false;
            }
        }

    }

}
