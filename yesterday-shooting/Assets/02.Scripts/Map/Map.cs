using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int xIndex = 18;
    public int yIndex = 10;
    public Vector2 SetPos(int _xIndex, int _yIndex)
    {
        return new Vector2(xIndex * _xIndex, yIndex * _yIndex);
    }
}