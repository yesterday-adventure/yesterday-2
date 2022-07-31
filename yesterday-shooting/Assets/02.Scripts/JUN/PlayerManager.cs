using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private Rigidbody2D rb2D;
    [SerializeField]private float speed = 5f;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x,y,0);
        rb2D.velocity = dir * speed;
    }
}
