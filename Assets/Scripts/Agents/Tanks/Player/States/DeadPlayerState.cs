public class DeadPlayerState : State, IObserver<StartRoundEventArgs>
{
    private readonly GameController gameController;

    public DeadPlayerState(
        IStateController controller,
        GameController gameController
        ) : base(controller)
    {
        this.gameController = gameController;
    }

    public override void Enter()
    {
        gameController.StartRoundSubject.Add(this);
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
        gameController.StartRoundSubject.Remove(this);
    }

    public void OnNotify(StartRoundEventArgs parameter)
    {
        SwitchToAlivePlayerState();
    }

    private void SwitchToAlivePlayerState()
    {
        controller.SwitchState<AlivePlayerState>();
    }
}