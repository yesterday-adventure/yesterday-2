using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletInfo : MonoBehaviour
{
    #region property
    [SerializeField] private float damage = 0; //������
    [SerializeField] private float attackDelay = 0; //���ݼӵ�
    #endregion

    #region get set
    public float Damage { get { return damage; } set { damage = value; }}
    public float AttackDelay { get { return attackDelay; } }
    #endregion
}
