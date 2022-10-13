using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManualFlipCode : MonoBehaviour
{
    SpriteRenderer _spriteRenderer;
    GameObject _player;

    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _player = GameObject.Find("Player");
    }

    private void Update()
    {
        Vector3 degree = _player.transform.position - transform.position;
        if (degree.x > 0)
        {
            _spriteRenderer.flipX = false;
        }
        else
        {
            _spriteRenderer.flipX = true;
        }
    }
}
