using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldActiveItem : MonoBehaviour
{
    [SerializeField] private ItemSkill item;
    public ItemSkill ItemSkill
    {
        get { return item; }
        set { item = value; }
    }

    public bool Use()
    {
        return item.Skill();
    }   
}
