using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    /*private void Start()
    {
        Debug.Log(DataManager.instance.path);
    }*/

    public void Start()
    {
        Debug.Log(DataManager.instance.nowPlayer.playing);
    }
}
