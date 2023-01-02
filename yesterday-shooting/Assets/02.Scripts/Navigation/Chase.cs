using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    private Vector3Int beforeTargetPos = Vector3Int.zero;
    private Vector3 nextPos;

    protected AIBrain _brain;

    private void Awake()
    {
        _brain = transform.GetComponent<AIBrain>();
    }

    private void Update()
    {
        TakeAction();
    }

    public void TakeAction()
    {
        Vector3Int targetPos = MapManager.Instance.GetTilePos(_brain.target.position);
        if(targetPos != beforeTargetPos)
        {
            _brain.Agent.Destination = targetPos;
            beforeTargetPos = targetPos;
            SetNextPosition();
        }
        if(Vector3.Distance(nextPos,transform.position) <= 0.2)
        {
            SetNextPosition();
        }
        
        _brain.Move((nextPos - transform.position).normalized);
    }

    private void SetNextPosition()
    {
        if(_brain.Agent.CanMovePath == false)
        {
            _brain.Move(Vector2.zero);
            nextPos = transform.position;
        }
        else
        {
            nextPos = MapManager.Instance.GetWorldPos(_brain.Agent.GetNextTarget());
        }
    }
}
