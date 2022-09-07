using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    NavMeshAgent2D agent;
    [SerializeField] Transform target;

    void Start()
    {
        agent = GetComponent<NavMeshAgent2D>();
    }

    void Update()
    {
        agent.destination = target.position;
        //agent.SetDestination(target.position); // 위에거랑 같은 역할
    }
}