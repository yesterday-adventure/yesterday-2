using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piece : MonoBehaviour
{
    private GameObject player;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        player = GameObject.Find("Player");
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        if (player == null)
            return;

        if (player.transform.position.x > transform.position.x)
        {
            spriteRenderer.flipX = false;
        }
        else if (player.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
    }
}
