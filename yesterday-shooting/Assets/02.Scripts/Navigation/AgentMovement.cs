using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D _rigid;

    [SerializeField]private float speed = 0;

    public float Speed{
        get{return speed;}
        set{speed = value;}
    }
    float followSpeed = 0f;
    protected Vector2 _movementDirection;

    protected void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        followSpeed = speed;
    }
    public void MoveAgent(Vector2 movementInput)
    {
        if (movementInput.sqrMagnitude > 0)
        {
            if(Vector2.Dot(movementInput, _movementDirection) <= 0)
            {
                followSpeed = 0;
                _rigid.velocity = Vector2.zero;
            }
            else
            {
                followSpeed = speed;
            }
            Debug.Log(Vector2.Dot(movementInput, _movementDirection) + " : " + followSpeed);
            // else
            // {
            //     followSpeed = speed;
            // }


            _movementDirection = movementInput.normalized;
        }
        else
            followSpeed = 0;
    }


    private void FixedUpdate()
    {
        _rigid.velocity = _movementDirection * followSpeed;
    }
}
