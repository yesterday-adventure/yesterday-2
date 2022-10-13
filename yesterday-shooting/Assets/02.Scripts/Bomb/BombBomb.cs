using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBomb : MonoBehaviour
{
    PlayerMove playerMove;

    // Start is called before the first frame update
    void Start()
    {
        playerMove = FindObjectOfType<PlayerMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerMove.now_bomb++;
            Destroy(gameObject);
        }
    }
}
