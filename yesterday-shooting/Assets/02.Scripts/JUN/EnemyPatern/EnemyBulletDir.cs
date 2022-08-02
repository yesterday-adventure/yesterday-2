using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDir : MonoBehaviour
{
    public enum FireDir : short
    {
        right = 0,
        left = 1,
        down = 2,
        up = 3,
        follow = 4,
    }
    public FireDir fireDir;
}
