using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOTweenTest : MonoBehaviour
{
    [SerializeField] private Ease ease;
    private void Start() {
        //ItemDropAnim();
    }
    public void ItemDropAnim() {
        transform.DOJump(transform.position, 3, 1, 2.5f, false).SetEase(ease);
    }
}
