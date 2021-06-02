public class SpawnEnemyState : State, IObserver<DieArgs>
{
    private readonly ISubject<DieArgs> killerSubject;

    public SpawnEnemyState(
        IStateController controller,
        ISubject<DieArgs> killerSubject
        ) : base(controller)
    {
        this.killerSubject = killerSubject;
    }

    public override void Enter()
    {
        base.Enter();

        killerSubject.Add(this);

        CoroutinesHelperSingleton.Instance.WaitForSeconds(3.25f, () => SwitchToChaseEnemyState()); // TODO: 3.25f?
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

    public void OnNotify(DieArgs param)
    {
        controller.SwitchState<DeadEnemyState>();
    }

    private void SwitchToChaseEnemyState()
    {
        controller.SwitchState<ChaseEnemyState>();
    }
}