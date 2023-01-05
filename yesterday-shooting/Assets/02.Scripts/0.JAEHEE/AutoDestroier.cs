using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroier : MonoBehaviour
{
    [SerializeField] private float time;

    private void OnEnable()
    {
        Destroy(gameObject, time);
    }
}
