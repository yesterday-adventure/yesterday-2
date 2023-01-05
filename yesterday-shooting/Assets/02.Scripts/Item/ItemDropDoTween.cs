using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemDropDoTween : MonoBehaviour
{
    [SerializeField] private Ease ease;
    Sequence seq = null;
    Vector2 pos;
    private void Start()
    {
        seq = DOTween.Sequence();
        ItemDropAnim();
    }

    public void ItemDropAnim()
    {
        pos = (Vector2)transform.position + (Random.insideUnitCircle / 2);
        if (transform.name == "bomb")
        {
            DataManager.instance.afterData.dropBomb.Add(pos);
        }
        else
        {
            DataManager.instance.afterData.dropCoin.Add(pos);
        }
        seq.Append(transform.DOJump(pos, 1, 1, 1f).SetEase(ease));
    }

    private void OnDisable()
    {
        seq.Kill();
    }
}
