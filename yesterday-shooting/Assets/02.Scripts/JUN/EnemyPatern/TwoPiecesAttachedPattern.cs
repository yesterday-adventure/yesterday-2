using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPiecesAttachedPattern : MonoBehaviour
{
    public GameObject Piece;
    private void OnDisable()
    {
        PoolManager.Instance.Pop(Piece,transform.position,Quaternion.identity);
        PoolManager.Instance.Pop(Piece,transform.position,Quaternion.identity);
    }
}
