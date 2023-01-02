using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1_1BossHandCol : MonoBehaviour
{
    Collider2D _collider;
    
    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();
    }

    public void BoxColOn()
    {
        _collider.enabled = true;
    }
    public void BoxColOff()
    {
        _collider.enabled = false;
    }
    public void EndOfAnimation()
    {
        Destroy(gameObject);
    }
}
