using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BossLightChange : MonoBehaviour
{
    public int speed = 1;
    private float degree = 0;
    public float inten;
    [SerializeField] private Light2D _light;

    void Update()
    {
        //�̰� �� �۵��ϴ°���
        degree += speed * Time.deltaTime;
        float radian = degree * Mathf.PI / 180; //���Ȱ�
        inten = (Mathf.Cos(radian) + 1) / 2 * 1.2f;
        _light.intensity = inten;
    }
}