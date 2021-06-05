public class DodgeEnemyState : AliveEnemyStateBase
{
    private readonly EnemyStateData enemyStateData;
    private readonly INavMeshAgent navMeshAgent;

    public DodgeEnemyState(
        IStateController controller,
        EnemyStateData enemyStateData,
        INavMeshAgent navMeshAgent
        ) : base(controller)
    {
        this.enemyStateData = enemyStateData;
        this.navMeshAgent = navMeshAgent;
    }

    public override void Enter()
    {
        base.Enter();

        navMeshAgent.Resume();

        SetDestination();
    }

    public override void Update()
    {
        if (navMeshAgent.RemainingDistance <= enemyStateData.RemainingDistance)
        {
            SwitchToChaseEnemyState();
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

    // TODO: Same as ChaseEnemyState seems like
    private void SetDestination()
    {
        // Return true if it can set destination and also sets destination
        if (navMeshAgent.CanSetDestinationInsideCircle(enemyStateData.MinDistance, enemyStateData.MaxDistance))
        {
            return;
        }
        else
        {
            SetDestination();
        }
    }

    private void SwitchToChaseEnemyState()
    {
        controller.SwitchState<ChaseEnemyState>();
    }
}