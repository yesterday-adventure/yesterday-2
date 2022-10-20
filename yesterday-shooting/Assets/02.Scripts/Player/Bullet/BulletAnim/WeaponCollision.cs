using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    Rigidbody2D rigid = null;
    
    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        PoolManager.Instance.Push(gameObject);
    }
}
