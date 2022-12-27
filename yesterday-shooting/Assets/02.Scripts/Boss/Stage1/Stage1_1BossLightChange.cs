using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Stage1_1BossLightChange : MonoBehaviour
{
    public int speed = 1;
    private float degree = 0;
    public float inten;
    [SerializeField] private Light2D _light;

    void Update()
    {
        //이거 왜 작동하는거지
        degree += speed * Time.deltaTime;
        float radian = degree * Mathf.PI / 180; //라디안값
        inten = (Mathf.Cos(radian) + 1) / 2 * 1.5f;
        _light.intensity = inten;
    }
}