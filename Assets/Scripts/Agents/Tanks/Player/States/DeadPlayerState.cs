public class DeadPlayerState : State, IObserver<CountdownArgs>
{
    private readonly ICountdownEvents countdownEvents;

    public DeadPlayerState(
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

    public void OnNotify(CountdownArgs countdownArgs)
    {
        SwitchToAlivePlayerState();
    }

    private void SwitchToAlivePlayerState()
    {
        controller.SwitchState<AlivePlayerState>();
    }
}