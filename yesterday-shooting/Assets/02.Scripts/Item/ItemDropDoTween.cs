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

    bool a = true;

    public void ItemDropAnim()
    {
        pos = (Vector2)transform.position + (Random.insideUnitCircle / 2);
        if (transform.name == "bomb")
        {
            foreach (Vector3 item in DataManager.instance.afterData.dropBomb)
            {
                if (item == transform.position)
                {
                    a = false;
                    break;
                }
            }
            //Debug.Log("폭탄 복사버그를 시작합니다!");
            if (a == true) {
                DataManager.instance.afterData.dropBomb.Add(pos);
            }
        }
        else
        {
            foreach (Vector3 item in DataManager.instance.afterData.dropCoin)
            {
                if (item == transform.position)
                {
                    a = false;
                    break;
                }
            }

            if (a == true)
            {
                /*Debug.Log(gameObject.name);
                Debug.Log("코인 복사버그를 시작합니다!");*/
                DataManager.instance.afterData.dropCoin.Add(pos);
            }
        }

        seq.Append(transform.DOJump(pos, 1, 1, 1f).SetEase(ease));
    }

    private void OnDisable()
    {
        seq.Kill();
    }
}
