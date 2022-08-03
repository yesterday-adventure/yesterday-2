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

    public LayerMask wallLayer;
    
    private bool iswallR;
    private bool iswallL;
    private bool iswallU;
    private bool iswallD;
    private bool chL = true;
    private bool chR = true;
    private bool chU = true;
    private bool chD = true;
    private int num = 0;
    private int num1 = 0;
    private void OnEnable()
    {
        useSkill = false;
        target = GameObject.Find("Player");
        StartCoroutine("Rush");
        StartCoroutine("Move");
    }

    private void Update()
    {
        iswallR = Physics2D.Raycast(transform.position,Vector2.right,transform.localScale.x / 2f + 0.05f,wallLayer);
        iswallL = Physics2D.Raycast(transform.position,Vector2.left,transform.localScale.x / 2f + 0.05f,wallLayer);
        iswallU = Physics2D.Raycast(transform.position,Vector2.up,transform.localScale.x / 2f + 0.05f,wallLayer);
        iswallD = Physics2D.Raycast(transform.position,Vector2.down,transform.localScale.x / 2f + 0.05f,wallLayer);

        if(iswallR && chR)
        {
            StopCoroutine("Move");
            StartCoroutine("Move");
            chR = false;
            chL = true;
            chU = true;
            chD = true;
        }
        if(iswallL && chL)
        {
            StopCoroutine("Move");
            StartCoroutine("Move");
            chR = true;
            chL = false;
            chU = true;
            chD = true;
        }
        if(iswallU && chU)
        {
            StopCoroutine("Move");
            StartCoroutine("Move");
            chR = true;
            chL = true;
            chU = false;
            chD = true;
        }
        if(iswallD && chD)
        {
            StopCoroutine("Move");
            StartCoroutine("Move");
            chR = true;
            chL = true;
            chU = true;
            chD = false;
        }
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
                        yield return null;
                    }
                }
                else
                {
                    while(true)
                    {
                        transform.position += skillspeed * Time.deltaTime * Vector3.right;
                        yield return null;
                    }
                }
            }
            yield return null;
        }
    } 

    IEnumerator Move()
    {
        if(iswallD && iswallL)
        {
            if(num == 4)
            {
                num1 = 2;
            }
            else
            {
                num1 = 4;
            }
        }
        if(iswallD && iswallR)
        {
            if(num == 1)
            {
                num1 = 4;
            }
            else
            {
                num1 = 1;
            }
        }
        if(iswallU && iswallL)
        {
            if(num == 3)
            {
                num1 = 2;
            }
            else
            {
                num1 = 3;
            }
        }
        if(iswallU && iswallR)
        {
            if(num == 3)
            {
                num1 = 1;
            }
            else
            {
                num1 = 3;
            }
        }
        while(true)
        {
            random = Random.Range(1,5);
            while(random == num || random == num1)
            {
                random = Random.Range(1,5);
            }
            switch(random)
            {
                case 1:
                    Debug.Log("1");
                    while(true)
                    {
                        transform.position += speed * Time.deltaTime * Vector3.right;
                        num = 1;
                        yield return null;
                    }
                case 2:
                    Debug.Log("2");
                    while(true)
                    {
                        transform.position += speed * Time.deltaTime * Vector3.left;
                        num = 2;
                        yield return null;
                    }
                case 3:
                    Debug.Log("3");
                    while(true)
                    {
                        transform.position += speed * Time.deltaTime * Vector3.up;
                        num = 3;
                        yield return null;
                    }
                case 4:
                    Debug.Log("4");
                    while(true)
                    {
                        transform.position += speed * Time.deltaTime * Vector3.down;
                        num = 4;
                        yield return null;
                    }
                default:
                    break;
            }
            yield return null;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Wall") && useSkill)
        {
            StopCoroutine("Rush");
            StartCoroutine("Rush");
            StartCoroutine("Move");
            StartCoroutine("Move");
        }
    }
}