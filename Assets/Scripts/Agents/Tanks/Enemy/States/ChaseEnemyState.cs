// TODO: Apply SOLID

using UnityEngine;
using UnityEngine.AI;

public class ChaseEnemyState : State, IObserver
{
    private readonly ChaseEnemyStateData chaseEnemyStateData;
    private readonly EnemyStateData enemyStateData;
    private readonly Transform agent;
    private readonly NavMeshAgent navMeshAgent;
    private readonly Transform player;
    private readonly ISubject killerSubject;

    public ChaseEnemyState(
        IStateController controller,
        ChaseEnemyStateData chaseEnemyStateData,
        EnemyStateData enemyStateData,
        Transform agent,
        NavMeshAgent navMeshAgent,
        Transform player,
        ISubject killerSubject
        ) : base(controller)
    {
        this.chaseEnemyStateData = chaseEnemyStateData;
        this.enemyStateData = enemyStateData;
        this.agent = agent;
        this.navMeshAgent = navMeshAgent;
        this.player = player;
        this.killerSubject = killerSubject;
    }

    public override void Enter()
    {
        base.Enter();

        killerSubject.Add(this);

        navMeshAgent.isStopped = false;

        SetDestination();
    }

    public override void Update()
    {
        if (Vector3.SqrMagnitude(player.position - agent.position) <= enemyStateData.VisionRange * enemyStateData.VisionRange)
        {
            controller.SwitchState<AttackEnemyState>();
            return;
        }

        if (navMeshAgent.remainingDistance <= chaseEnemyStateData.DestinationRemainingDistance)
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

        Vector3 destination = new Vector3(agent.position.x + temp.x, 0, agent.position.z + temp.y);
        Debug.Log(destination);

        NavMeshPath path = new NavMeshPath();
        navMeshAgent.CalculatePath(destination, path);
        if (path.status == NavMeshPathStatus.PathComplete)
        {
            navMeshAgent.SetDestination(destination);
        }
        else
        {
            SetDestination();
        }
    }
}