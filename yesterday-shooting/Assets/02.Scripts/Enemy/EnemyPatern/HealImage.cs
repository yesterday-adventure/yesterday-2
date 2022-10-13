using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealImage : MonoBehaviour
{
    private float time;

    void Update()
    {
        time += Time.deltaTime;
        if(time > 1)
        {
            Destroy(gameObject);//풀메니저로
        }        
    }
}
