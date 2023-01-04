using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSkill : MonoBehaviour
{
    public string titleTxt;
    public string captionTxt;
    public float maxCool;
    public abstract bool Skill();
}