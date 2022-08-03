using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class check : MonoBehaviour
{
    private void Start()
    {
        Debug.Log(DataManager.instance.path);
        Debug.Log(DataManager.instance.nowPlayer.playing);
    }

    /*public void Start()
    {
        Debug.Log(DataManager.instance.nowPlayer.playing);
    }*/

    public void Back()
    {
        Debug.Log("gg");
    }
}
