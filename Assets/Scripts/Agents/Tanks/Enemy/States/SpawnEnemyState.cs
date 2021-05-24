public class SpawnEnemyState : State, IObserver
{
    private readonly ISubject killerSubject;

    public SpawnEnemyState(
        IStateController controller,
        ISubject killerSubject
        ) : base(controller)
    {
        this.killerSubject = killerSubject;
    }

    public override void Enter()
    {
        base.Enter();

        killerSubject.Add(this);

        RoutineHelperSingleton.Instance.WaitForSeconds(0.25f, () => SwitchToChaseEnemyState());
    }

    public override void Update()
    {
        return;
    }

    public override void FixedUpdate()
    {
        return;
    }

    public override void Exit()
    {
        killerSubject.Remove(this);

        base.Exit();
    }

    public void OnNotify()
    {
        controller.SwitchState<DeadEnemyState>();
    }

    private void SwitchToChaseEnemyState()
    {
        controller.SwitchState<ChaseEnemyState>();
    }
}