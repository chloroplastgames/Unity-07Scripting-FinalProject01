// TODO Apply SOLID

using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemyState : State, IObserver
{
    private readonly Transform agent;
    private readonly NavMeshAgent navMeshAgent;
    private readonly Transform player;
    private readonly ISubject killerSubject;
    private readonly ChaseEnemyStateData chaseEnemyStateData;

    public ChaseEnemyState(
        IStateController controller,
        Transform agent,
        NavMeshAgent navMeshAgent,
        Transform player,
        ISubject killerSubject,
        ChaseEnemyStateData chaseEnemyStateData
        ) : base(controller)
    {
        this.agent = agent;
        this.navMeshAgent = navMeshAgent;
        this.player = player;
        this.killerSubject = killerSubject;
        this.chaseEnemyStateData = chaseEnemyStateData;
    }

    public override void Enter()
    {
        base.Enter();

        killerSubject.Add(this);

        SetDestination();
    }

    public override void Update()
    {
        // TODO Check line of sight too, SqrMagnitude
        if (Vector3.Distance(agent.position, player.position) <= chaseEnemyStateData.VisionRange)
        {
            controller.SwitchState<AttackEnemyState>();
            return;
        }

        if (navMeshAgent.remainingDistance <= chaseEnemyStateData.MinDestinationRemainingDistance)
        {
            SetDestination();
        }
    }

    public override void FixedUpdate()
    {
        return;
    }

    public override void Exit()
    {
        base.Exit();

        killerSubject.Remove(this);

        navMeshAgent.isStopped = true;
    }

    public void OnNotify()
    {
        controller.SwitchState<DeadEnemyState>();
    }

    private void SetDestination()
    {
        Vector2 temp =
            Random.insideUnitCircle * (Random.Range(chaseEnemyStateData.MinChaseDistance, chaseEnemyStateData.MaxChaseDistance));

        // XZ movement
        Vector3 destination = new Vector3(agent.position.x + temp.x, 0, agent.position.z + temp.y);
        Debug.Log(destination);

        NavMeshPath path = new NavMeshPath();
        navMeshAgent.CalculatePath(destination, path);
        if (path.status == NavMeshPathStatus.PathComplete)
        {
            navMeshAgent.SetDestination(destination);
        }
        else // Can't reach destination
        {
            SetDestination();
        }
    }
}