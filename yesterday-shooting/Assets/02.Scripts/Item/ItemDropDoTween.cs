using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemDropDoTween : MonoBehaviour
{
    [SerializeField] private Ease ease;
    private void Start()
    {
        ItemDropAnim();
    }

    public void ItemDropAnim()
    {
        transform.DOJump((Vector2)transform.position + (Random.insideUnitCircle / 2), 1, 1, 1f).SetEase(ease);
    }
}
