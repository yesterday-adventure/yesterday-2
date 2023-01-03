using UnityEngine;
using UnityEngine.UI;

public class ItemCoolShow : MonoBehaviour
{
    [SerializeField] Image image;

    private void Awake()
    {
        if(image == null)
            image = GetComponent<Image>();
    }

    void Update()
    {
        if(PlayerItem.Instance.item == null)
        {
            image.enabled = false;
        }
        if(PlayerItem.Instance.item.ItemSkill.maxCool != 0)
        image.fillAmount = 1 - PlayerItem.Instance.cool / PlayerItem.Instance.item.ItemSkill.maxCool;
    }
}
