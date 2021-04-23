using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class SetDestinationBehaviour : MonoBehaviour, ISetDestination
{
    private NavMeshAgent myNavMeshAgent;

    private void Awake()
    {
        myNavMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void SetDestination(Vector3 destination)
    {
        myNavMeshAgent.SetDestination(destination);
    }
}