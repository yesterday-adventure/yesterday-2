using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenTest : MonoBehaviour
{
    [SerializeField] private Ease ease;

    [SerializeField] Vector2 pos;
    private void Start() {
        if (!gameObject.CompareTag("Enemy")) transform.DOMove(pos, 5f);
        else { transform.DOMove(pos, 5f).SetEase(ease); }
        // ItemDropAnim();
    }
    public void ItemDropAnim() {
        transform.DOJump(transform.position, 3, 1, 2f, false).SetEase(ease);
    }
}
