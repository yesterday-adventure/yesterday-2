using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenTest : MonoBehaviour
{
    [SerializeField] private Ease ease;
    public void ItemDropAnim() {
        transform.DOJump(transform.position, 3, 1, 1f, false).SetEase(ease);
    }
}
