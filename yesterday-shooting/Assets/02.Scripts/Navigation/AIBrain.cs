using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Events;

public class AIBrain : MonoBehaviour
{
    public UnityEvent<Vector2> OnMovementCommend;

    private AgentMovement _movement;
    public NavAgent Agent;

    public Transform target = null;
    private void Awake()
    {
        _movement = GetComponent<AgentMovement>();
        Agent = GetComponent<NavAgent>();
    }
    private void OnEnable()
    {
        target = GameManager.Instance.PlayerTrm;
    }
    public void Move(Vector2 direction)
    {
        OnMovementCommend?.Invoke(direction);
    }
}
