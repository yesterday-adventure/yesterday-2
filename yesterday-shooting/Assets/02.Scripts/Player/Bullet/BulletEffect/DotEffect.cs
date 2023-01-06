using UnityEngine;
using DG.Tweening;

public class DotEffect : MonoBehaviour
{
    [Header("��Ʈ������")]
    [SerializeField] float dotDamage = 0;
    [Header("�ݺ�Ƚ��")]
    [SerializeField] float loopTime = 0;
    [Header("��Ʈ������ ����")]
    [SerializeField] float dotTick = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") || collision.CompareTag("Boss"))
        {
            collision.gameObject.GetComponent<DamageOverTime>().Dot(dotDamage, loopTime, dotTick);
        }
    }
}
