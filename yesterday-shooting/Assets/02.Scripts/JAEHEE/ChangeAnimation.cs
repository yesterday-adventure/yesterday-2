using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimation : MonoBehaviour
{
    Animator _animator;
    MonsterAI _monsterAI;

    private void Awake()
    {
        _monsterAI = GetComponent<MonsterAI>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_monsterAI.IsMove)
        {
            _animator.SetBool("IsMove", true);
        }
        else
        {
            _animator.SetBool("IsMove", false);
        }
    }


}
