using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemDropDoTween : MonoBehaviour
{
    [SerializeField] private Ease ease;
    Sequence seq = null;
    private void Start()
    {
        seq = DOTween.Sequence();
        ItemDropAnim();
    }

    public void ItemDropAnim()
    {
        seq.Append(transform.DOJump((Vector2)transform.position + (Random.insideUnitCircle / 2), 1, 1, 1f).SetEase(ease));
    }

    private void OnDisable()
    {
        seq.Kill();
    }
}
