public abstract class AliveEnemyStateBase : State, IObserver<EndRoundArgs>, IObserver<TimerArgs>
{
    private readonly IHUDEvents hudEvents;

    protected AliveEnemyStateBase(
        IStateController controller,
        IHUDEvents hudEvents
        ) : base(controller)
    {
        this.hudEvents = hudEvents;
    }

    public override void Enter()
    {
        base.Enter();

        hudEvents.TimerSubject.Add(this);

        GameManagerSingleton.Instance.RoundEnder.Add(this);
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

        hudEvents.TimerSubject.Remove(this);

        GameManagerSingleton.Instance.RoundEnder.Remove(this);
    }

    public void OnNotify(TimerArgs parameter)
    {
        SwitchToDeadEnemyState();
    }

    public void OnNotify(EndRoundArgs endRoundArgs)
    {
        SwitchToDeadEnemyState();
    }

    protected void SwitchToDeadEnemyState()
    {
        controller.SwitchState<DeadEnemyState>();
    } 
}