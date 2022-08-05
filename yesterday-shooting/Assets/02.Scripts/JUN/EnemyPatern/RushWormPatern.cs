using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushWormPatern : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
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

    Coroutine coroutineMove;
    private void OnEnable()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        useSkill = false;
        target = GameObject.Find("Player");
        StartCoroutine("Rush");
        coroutineMove = StartCoroutine(Move());
    }

    private void Update()
    {
        iswallR = Physics2D.Raycast(transform.position,Vector2.right,transform.localScale.x / 2f + 0.05f,wallLayer);
        iswallL = Physics2D.Raycast(transform.position,Vector2.left,transform.localScale.x / 2f + 0.05f,wallLayer);
        iswallU = Physics2D.Raycast(transform.position,Vector2.up,transform.localScale.x / 2f + 0.05f,wallLayer);
        iswallD = Physics2D.Raycast(transform.position,Vector2.down,transform.localScale.x / 2f + 0.05f,wallLayer);

        if(iswallR && chR)
        {
            if(coroutineMove != null)
                StopCoroutine(coroutineMove);
            coroutineMove = StartCoroutine(Move());
            chR = false;
            chL = true;
            chU = true;
            chD = true;
        }
        else if(iswallL && chL)
        {
            if(coroutineMove != null)
                StopCoroutine(coroutineMove);
            coroutineMove = StartCoroutine(Move());
            chR = true;
            chL = false;
            chU = true;
            chD = true;
        }
        else if(iswallU && chU)
        {
            if(coroutineMove != null)
                StopCoroutine(coroutineMove);
            coroutineMove = StartCoroutine(Move());
            chR = true;
            chL = true;
            chU = false;
            chD = true;
        }
        else if(iswallD && chD)
        {
            if(coroutineMove != null)
                StopCoroutine(coroutineMove);
            coroutineMove = StartCoroutine(Move());
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
                if(coroutineMove != null)
                    StopCoroutine(coroutineMove);
                useSkill = true;
                if(transform.position.x > target.transform.position.x)
                {
                    while(true)
                    {
                        _spriteRenderer.flipX = true;
                        transform.position += skillspeed * Time.deltaTime * Vector3.left;
                        num = 2;
                        yield return null;
                    }
                }
                else
                {
                    while(true)
                    {
                        _spriteRenderer.flipX = false;
                        transform.position += skillspeed * Time.deltaTime * Vector3.right;
                        num = 1;
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
            num = 4;
            num1 = 2;
        }
        if(iswallD && iswallR)
        {
            num = 1;
            num1 = 4;
        }
        if(iswallU && iswallL)
        {
            num = 3;
            num1 = 2;
        }
        if(iswallU && iswallR)
        {
            num = 3;
            num1 = 1;
        }
        while(true)
        {
            while(random == num || random == num1)
            {
                random = Random.Range(1,5);
            }
            Debug.Log(random);
            switch(random)
            {
                case 1:
                    while(true)
                    {
                        _spriteRenderer.flipX = false;
                        transform.position += speed * Time.deltaTime * Vector3.right;
                        num = 1;
                        yield return null;
                    }
                case 2:
                    while(true)
                    {
                        _spriteRenderer.flipX = true;
                        transform.position += speed * Time.deltaTime * Vector3.left;
                        num = 2;
                        yield return null;
                    }
                case 3:
                    while(true)
                    {
                        transform.position += speed * Time.deltaTime * Vector3.up;
                        num = 3;
                        yield return null;
                    }
                case 4:
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
            transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
            StopCoroutine("Rush");
            StartCoroutine("Rush");
            
        }
    }
}