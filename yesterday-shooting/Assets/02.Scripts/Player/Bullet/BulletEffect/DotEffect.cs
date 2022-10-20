using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DotEffect : MonoBehaviour
{
    [Header("도트데미지")]
    [SerializeField] float dotDamage = 0;
    [Header("반복횟수")]
    [SerializeField] float loopTime = 0;
    [Header("도트데미지 간격")]
    [SerializeField] float dotTick = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<DamageOverTime>().Dot(dotDamage, loopTime, dotTick);
    }
}
