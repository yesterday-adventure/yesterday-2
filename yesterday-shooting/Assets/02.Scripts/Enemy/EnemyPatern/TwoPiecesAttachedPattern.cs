using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoPiecesAttachedPattern : MonoBehaviour
{
    public GameObject Piece;
    private void OnDisable()
    {
        PoolManager.Instance.Pop(Piece,transform.position + new Vector3(Random.Range(0f,0.5f),Random.Range(0f,0.5f),0),Quaternion.identity);
        PoolManager.Instance.Pop(Piece,transform.position + new Vector3(Random.Range(0f,-0.5f),Random.Range(0f,-0.5f),0),Quaternion.identity);
    }
}
