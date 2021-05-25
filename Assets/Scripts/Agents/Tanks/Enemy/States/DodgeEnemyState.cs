public class DodgeEnemyState : State, IObserver
{
    private readonly EnemyStateData enemyStateData;
    private readonly INavMeshAgent navMeshAgent;
    private readonly ISubject killerSubject;

    public DodgeEnemyState(
        IStateController controller,
        EnemyStateData enemyStateData,
        INavMeshAgent navMeshAgent,
        ISubject killerSubject
        ) : base(controller)
    {
        this.enemyStateData = enemyStateData;
        this.navMeshAgent = navMeshAgent;
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
        if (navMeshAgent.GetRemainingDistance() <= enemyStateData.RemainingDistance)
        {
            controller.SwitchState<ChaseEnemyState>();
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

    public void OnNotify()
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