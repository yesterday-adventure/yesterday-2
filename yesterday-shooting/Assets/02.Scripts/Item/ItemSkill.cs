using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSkill : MonoBehaviour
{
    public int maxColl;
    public abstract bool Skill();
}