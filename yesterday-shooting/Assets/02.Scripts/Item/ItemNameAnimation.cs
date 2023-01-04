using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ItemNameAnimation : MonoBehaviour
{
    public static ItemNameAnimation Instance = null;
    Vector3 origin;

    TextMeshProUGUI title;
    TextMeshProUGUI caption;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.Log("Multiple ItemNameAnimation");
            Destroy(gameObject);
        }
        title = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        caption = transform.GetChild(1).GetComponent<TextMeshProUGUI>();

        origin = transform.position;
    }
    Sequence seq;

    [ContextMenu("¾Ö´Ï¸Þ")]
    private void GetItemAnimation()
    {
        seq.Kill();
        transform.position = new Vector2(transform.position.x - 3000, transform.position.y);
        seq = DOTween.Sequence();
        seq.Append(transform.DOMove(origin, 1f, false));
        seq.AppendInterval(1);
        seq.Append(transform.DOMove(new Vector2(origin.x + 3000, origin.y), 1f, false));
    }

    public void InitText(string titleTxt, string captionTxt)
    {
        title.text = titleTxt;
        caption.text = captionTxt;
        GetItemAnimation();
    }
}
