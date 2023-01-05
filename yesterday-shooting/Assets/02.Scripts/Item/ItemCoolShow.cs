using UnityEngine;
using UnityEngine.UI;

public class ItemCoolShow : MonoBehaviour
{
    [SerializeField] Image image;
    [SerializeField] Image image1;

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
            image1.enabled = false;
        }
        else
        {
            image1.enabled = true;
            image.enabled = true;
            if(PlayerItem.Instance.item.ItemSkill.maxCool != 0)
                image.fillAmount = 1 - PlayerItem.Instance.cool / PlayerItem.Instance.item.ItemSkill.maxCool;
        }
    }
}
