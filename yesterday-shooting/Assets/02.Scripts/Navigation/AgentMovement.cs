using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentMovement : MonoBehaviour
{
    private Rigidbody2D _rigid;

    [SerializeField]protected float speed = 0;
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
            if(Vector2.Dot(movementInput, _movementDirection) < 0)
            {
                followSpeed = 0;
            }
            else
            {
                followSpeed = speed;
            }

            _movementDirection = movementInput.normalized;
        }
    }


    private void FixedUpdate()
    {
        _rigid.velocity = _movementDirection * followSpeed;
    }
}
