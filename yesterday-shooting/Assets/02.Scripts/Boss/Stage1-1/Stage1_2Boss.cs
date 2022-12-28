using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_2Boss : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
    }
}
