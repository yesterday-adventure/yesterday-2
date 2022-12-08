using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    [SerializeField] ItemSkil itemSkil;

    public void Use() {
        itemSkil?.Skil();
    }
}