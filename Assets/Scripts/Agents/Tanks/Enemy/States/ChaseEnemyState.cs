using UnityEngine;

public class ChaseEnemyState : State, IObserver<DieArgs>
{
    private readonly EnemyStateData enemyStateData;
    private readonly INavMeshAgent navMeshAgent;
    private readonly Transform agent;
    private readonly Transform player;
    private readonly ISubject<DieArgs> killerSubject;

    public ChaseEnemyState(
        IStateController controller,
        EnemyStateData enemyStateData,
        INavMeshAgent navMeshAgent,
        Transform agent,
        Transform player,
        ISubject<DieArgs> killerSubject
        ) : base(controller)
    {
        this.enemyStateData = enemyStateData;
        this.navMeshAgent = navMeshAgent;
        this.agent = agent;
        this.player = player;
        this.killerSubject = killerSubject;
    }

    public override void Enter()
    {
        base.Enter();

        killerSubject.Add(this);

        navMeshAgent.Resume();

        SetDestination();
    }

    public override void Update()
    {
        if (Vector3.SqrMagnitude(player.position - agent.position) <= enemyStateData.VisionRange * enemyStateData.VisionRange)
        {
            controller.SwitchState<AttackEnemyState>();
            return;
        }

        if (navMeshAgent.GetRemainingDistance() <= enemyStateData.RemainingDistance)
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

        navMeshAgent.Stop();
    }

    public void OnNotify(DieArgs param)
    {
        controller.SwitchState<DeadEnemyState>();
    }

    private void SetDestination()
    {
        if (navMeshAgent.CanSetDestinationInsideCircle(enemyStateData.MinDistance, enemyStateData.MaxDistance))
        {
            return;
        }
        else
        {
            SetDestination();
        }
    }
}