using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollsionAnim : MonoBehaviour
{
    Rigidbody2D rigid = null;
    Animator animator = null;

    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(rigid);
        animator.SetTrigger("IsCollision");
    }

    public void EndOfAnimation()
    {
        PoolManager.Instance.Push(gameObject);
    }
}
