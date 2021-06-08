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
        base.Enter();

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
        base.Exit();

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