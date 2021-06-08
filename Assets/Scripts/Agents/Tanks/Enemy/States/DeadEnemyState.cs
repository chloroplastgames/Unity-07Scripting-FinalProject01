public class DeadEnemyState : State, IObserver<StartRoundEventArgs>
{
    private readonly GameController gameController;

    public DeadEnemyState(
        IStateController controller,
        GameController gameController
        ) : base(controller)
    {
        this.gameController = gameController;
    }

    public override void Enter()
    {
        base.Enter();

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
        base.Exit();

        gameController.StartRoundSubject.Remove(this);
    }

    public void OnNotify(StartRoundEventArgs parameter)
    {
        SwitchToSpawnEnemyState();
    }

    private void SwitchToSpawnEnemyState()
    {
        controller.SwitchState<SpawnEnemyState>();
    }
}