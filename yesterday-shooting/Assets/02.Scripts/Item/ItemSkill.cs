using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSkill : MonoBehaviour
{
    public float maxCool;
    public abstract bool Skill();
}