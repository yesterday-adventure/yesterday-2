using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{
    [SerializeField] GameObject room;
    private void Update()
    {
        Collider2D hitPlayer = Physics2D.OverlapBox(transform.position, new Vector2(17f, 9f), 0, 1 << 8);
        if(hitPlayer != null)
        {
            room.SetActive(true);
        }
    }


}
