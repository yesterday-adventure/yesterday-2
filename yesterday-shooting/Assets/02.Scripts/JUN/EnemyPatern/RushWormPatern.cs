using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushWormPatern : MonoBehaviour
{
    private GameObject target;
    private float skillspeed = 10;
    private float speed = 3;

    private int random = 0;

    private bool useSkill = false;
    public GameObject cm = null;

    private void OnEnable()
    {
        useSkill = false;
        target = GameObject.Find("Player");
        StartCoroutine("Rush");
        StartCoroutine("Move");
    }

    IEnumerator Rush()
    {
        yield return new WaitForSeconds(4f);
        while(true)
        {
            if(transform.position.y > target.transform.position.y - 0.5f && transform.position.y < target.transform.position.y + 0.5f)
            {
                StopCoroutine("Move");
                useSkill = true;
                if(transform.position.x > target.transform.position.x)
                {
                    while(true)
                    {
                        transform.position += skillspeed * Time.deltaTime * Vector3.left;
                        yield return new WaitForSeconds(0.001f);
                    }
                }
                else
                {
                    while(true)
                    {
                        transform.position += skillspeed * Time.deltaTime * Vector3.right;
                        yield return new WaitForSeconds(0.001f);
                    }
                }
            }
            yield return null;
        }
    } 

    IEnumerator Move()
    {
        while(true)
        {
            random = Random.Range(1,5);
            switch(random)
            {
                case 1:
                    while(true)
                    {
                        transform.position += speed * Time.deltaTime * Vector3.right;
                        yield return new WaitForSeconds(0.001f);
                    }
                case 2:
                    while(true)
                    {
                        transform.position += speed * Time.deltaTime * Vector3.left;
                        yield return new WaitForSeconds(0.001f);
                    }
                case 3:
                    while(true)
                    {
                        transform.position += speed * Time.deltaTime * Vector3.up;
                        yield return new WaitForSeconds(0.001f);
                    }
                case 4:
                    while(true)
                    {
                        transform.position += speed * Time.deltaTime * Vector3.down;
                        yield return new WaitForSeconds(0.001f);
                    }
                default:
                    break;
            }
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            StopCoroutine("Move");
            StartCoroutine("Move");
        }

        if(other.gameObject.CompareTag("Wall") && useSkill)
        {
            StopCoroutine("Rush");
            StartCoroutine("Rush");
            StartCoroutine("Move");
        }
    }
}