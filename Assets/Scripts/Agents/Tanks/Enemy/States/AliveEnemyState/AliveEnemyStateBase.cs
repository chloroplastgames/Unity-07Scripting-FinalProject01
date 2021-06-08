/// <summary>
/// Abstract class to hold observer for end round event
/// </summary>

public abstract class AliveEnemyStateBase : State, IObserver<EndRoundEventArgs>
{
    private readonly GameController gameController;

    protected AliveEnemyStateBase(
        IStateController controller,
        GameController gameController
        ) : base(controller)
    {
        this.gameController = gameController;
    }

    public override void Enter()
    {
        gameController.EndRoundSubject.Add(this);
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
        gameController.EndRoundSubject.Remove(this);
    }

    public void OnNotify(EndRoundEventArgs parameter)
    {
        SwitchToDeadEnemyState();
    }

    private void SwitchToDeadEnemyState()
    {
        controller.SwitchState<DeadEnemyState>();
    }
}