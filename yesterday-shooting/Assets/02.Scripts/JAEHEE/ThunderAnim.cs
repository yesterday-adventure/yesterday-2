using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderAnim : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator animator;
    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

}
