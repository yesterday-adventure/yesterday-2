using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemNameAnimation : MonoBehaviour
{
    public static ItemNameAnimation Instance = null;
    Vector3 origin;

    Sequence seq;
    [SerializeField]TextMeshProUGUI title;
    [SerializeField]TextMeshProUGUI caption;
    [SerializeField]Image image;

    private bool isChanging = false;
    public bool IsChanging => isChanging;
    private void Awake()
    {
        image = GetComponent<Image>();
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

        ActiveChanger(false);
    }

    [ContextMenu("¾Ö´Ï¸Þ")]
    private void GetItemAnimation()
    {
        seq.Kill();
        seq = DOTween.Sequence();
        seq.AppendCallback(()=>{
            isChanging = true;
            transform.position = new Vector2(origin.x - 3000, origin.y);
        })    
        .Append(transform.DOMove(origin, 0.5f, false))
        .AppendInterval(2)
        .Append(transform.DOMove(new Vector2(origin.x + 3000, origin.y), 1f, false))
        .AppendCallback(()=>{
        isChanging = false;
        ActiveChanger(false);
        });
    }

    public void InitText(string titleTxt, string captionTxt)
    {
        ActiveChanger(true);
        title.text = titleTxt;
        caption.text = captionTxt;
        GetItemAnimation();
    }

    private void ActiveChanger(bool value){
       image.enabled = value;
       title.gameObject.SetActive(value);
       caption.gameObject.SetActive(value);
    }
}
