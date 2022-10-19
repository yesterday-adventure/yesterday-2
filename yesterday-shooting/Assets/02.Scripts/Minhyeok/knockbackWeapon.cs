using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class knockbackWeapon : MonoBehaviour
{
    PlayerFire playerfire = null;
    private Rigidbody2D rb = null;
    Vector2 dir;
    [SerializeField] float pwr;
    PlayerFire.FireDir a;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log(11);
            dir = collision.transform.position - transform.position ;
            Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();
            Debug.Log(rigid.position);

            rigid.AddForce(dir * pwr);
            Debug.Log(rigid.position);
        }
    }
}
