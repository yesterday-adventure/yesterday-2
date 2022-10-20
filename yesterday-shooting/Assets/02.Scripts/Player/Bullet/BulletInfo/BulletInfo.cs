using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : MonoBehaviour
{
    #region property
    [SerializeField] private float damage = 0; //데미지
    [SerializeField] private float attackDelay = 0; //공격속도
    #endregion

    #region get set
    public float Damage { get { return damage; } }
    public float AttackDelay { get { return attackDelay; } }
    #endregion
}
