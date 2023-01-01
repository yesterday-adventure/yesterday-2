using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSkill : MonoBehaviour
{
    public int maxCool;
    public abstract bool Skill();
}