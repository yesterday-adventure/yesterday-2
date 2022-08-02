using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMonster : MonoBehaviour
{
    [SerializeField]private Rigidbody2D Rb2D = null;
    //[SerializeField]private Collision2D playerC = null;

    private void Awake()
    {
        Rb2D = GameObject.Find("Player").GetComponent<Rigidbody2D>();
        //playerC = GameObject.Find("Player").GetComponent<Collision2D>();
    }
    
    private void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Rb2D.AddForce(Vector2.up * 1);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Rb2D.velocity = Vector2.zero;
        }    
    }
}
