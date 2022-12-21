using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPotion : ItemSkil
{
    [SerializeField] private int itemMaxColl = 10;
    public override void Skil()
    {
        maxColl = itemMaxColl;
    }
}
