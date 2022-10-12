using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public int xIndex = 18;
    public int yIndex = 10;

    public float _MxIndex = 0.04f;
    public float _MyIndex = 0.08f;

    public Vector2 SetPos(int _xIndex, int _yIndex)
    {
        return new Vector2(xIndex * _xIndex, yIndex * _yIndex);
    }

    public Vector2 MiniMapSetPos(float _xIndex,float _yIndex)
    {
        return new Vector2(_MxIndex * _xIndex, _MyIndex * _yIndex);
    }

}