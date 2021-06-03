﻿using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentBehaviour : MonoBehaviour, INavMeshAgent
{
    public float RemainingDistance => navMeshAgent.remainingDistance;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    public bool CanSetDestinationInsideCircle(int min, int max)
    {
        Vector2 insideCircle = Random.insideUnitCircle * (Random.Range(min, max));

        Vector3 destination = new Vector3(transform.position.x + insideCircle.x, 0, transform.position.z + insideCircle.y);

        NavMeshPath path = new NavMeshPath();
        navMeshAgent.CalculatePath(destination, path);

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            navMeshAgent.SetDestination(destination);
            return true;
        }

        return false;
    }

    public void Stop()
    {
        navMeshAgent.isStopped = true;
        navMeshAgent.velocity = Vector3.zero;
    }

    public void Resume()
    {
        navMeshAgent.isStopped = false;
    }
}