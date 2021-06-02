using UnityEngine;

public class ChaseEnemyState : AliveEnemyStateBase
{
    private readonly EnemyStateData enemyStateData;
    private readonly INavMeshAgent navMeshAgent;
    private readonly Transform agent;
    private readonly Transform player;

    public ChaseEnemyState(
        IStateController controller,
        EnemyStateData enemyStateData,
        INavMeshAgent navMeshAgent,
        Transform agent,
        Transform player
        ) : base(controller)
    {
        this.enemyStateData = enemyStateData;
        this.navMeshAgent = navMeshAgent;
        this.agent = agent;
        this.player = player;
    }

    public override void Enter()
    {
        base.Enter();

        navMeshAgent.Resume();

        SetDestination();
    }

    public override void Update()
    {
        if (Vector3.SqrMagnitude(player.position - agent.position) <= enemyStateData.VisionRange * enemyStateData.VisionRange)
        {
            SwitchToAttackEnemyState();
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

        navMeshAgent.Stop();
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

    private void SwitchToAttackEnemyState()
    {
        controller.SwitchState<AttackEnemyState>();
    }
}