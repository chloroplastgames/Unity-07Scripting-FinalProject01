public class DeadEnemyState : State, IObserver<CountdownArgs>
{
    private readonly ICountdownEvents countdownEvents;

    public DeadEnemyState(
        IStateController controller,
        ICountdownEvents countdownEvents
        ) : base(controller)
    {
        this.countdownEvents = countdownEvents;
    }

    public override void Enter()
    {
        base.Enter();

        countdownEvents.CounterSubject.Add(this);
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
        base.Exit();

        countdownEvents.CounterSubject.Remove(this);
    }

    public void OnNotify(CountdownArgs parameter)
    {
        SwitchToSpawnEnemyState();
    }

    private void SwitchToSpawnEnemyState()
    {
        controller.SwitchState<SpawnEnemyState>();
    }
}