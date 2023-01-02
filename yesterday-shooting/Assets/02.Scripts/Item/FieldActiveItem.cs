using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldActiveItem : MonoBehaviour
{
    [SerializeField] private ItemSkill itme;
    public ItemSkill ItemSkill
    {
        get { return itme; }
        set { itme = value; }
    }

    public bool Use()
    {
        return itme.Skill();
    }   
}
