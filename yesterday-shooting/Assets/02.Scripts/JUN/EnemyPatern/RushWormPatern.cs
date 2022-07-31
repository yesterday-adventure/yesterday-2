using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushWormPatern : MonoBehaviour
{
    private GameObject target;
    private Rigidbody2D rb2D;
    private void OnEnable()
    {
        target = GameObject.Find("Player");
        rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine("Rush");
    }

    IEnumerator Rush()
    {
        while(true)
        {
            if(transform.position.x > target.transform.position.x)
            {
                rb2D.AddForce(Vector2.left * 500);
            }
            else
            {
                rb2D.AddForce(Vector2.right * 500);
            }
            yield return new WaitForSeconds(4f);
            rb2D.velocity = Vector2.zero;
        }
    } 

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {

            rb2D.velocity = Vector2.zero;
        }
    }
}
