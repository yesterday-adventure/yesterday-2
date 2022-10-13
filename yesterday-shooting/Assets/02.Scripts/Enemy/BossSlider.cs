using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossSlider : MonoBehaviour
{
    [SerializeField] EnemyHp enemyHp;
    private Slider slider;
    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    
    void Update()
    {
        slider.value = enemyHp.hp / 1000f;
    }
}
