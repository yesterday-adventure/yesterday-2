using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class knockbackWeapon : MonoBehaviour
{
    Vector2 dir;
    [SerializeField] float pwr;
    
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
