using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemSkil: MonoBehaviour
{
    EnemyHp enemyHp;
    public void CollCount() {
        // enemyHp.
    }

    protected int curColl;
    protected int maxColl;
    public abstract void Skil();
}