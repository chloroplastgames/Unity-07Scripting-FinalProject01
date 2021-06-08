using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Behaviour to roam with NavMeshAgent
/// </summary>

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshAgentBehaviour : MonoBehaviour, INavMeshAgent
{
    public float RemainingDistance => navMeshAgent.remainingDistance;

    private NavMeshAgent navMeshAgent;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Returns true and set destination if there is path and false otherwise
    public bool CanSetDestinationInsideCircle(int min, int max)
    {
        Vector2 insideCircle = Random.insideUnitCircle * (Random.Range(min, max));

        // XZ destination
        Vector3 destination = new Vector3(transform.position.x + insideCircle.x, 0, transform.position.z + insideCircle.y);

        NavMeshPath path = new NavMeshPath();
        navMeshAgent.CalculatePath(destination, path);

        if (path.status == NavMeshPathStatus.PathComplete)
        {
            // Has path
            navMeshAgent.SetDestination(destination);
            return true;
        }

        // No path
        return false;
    }

    public void Stop()
    {
        navMeshAgent.ResetPath();
        navMeshAgent.enabled = false;
    }

    public void Resume()
    {
        navMeshAgent.enabled = true;
    }
}