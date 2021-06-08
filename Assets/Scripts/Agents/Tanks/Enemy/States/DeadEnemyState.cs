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

    // Respawns when the round ends
    public void OnNotify(StartRoundEventArgs parameter)
    {
        SwitchToSpawnEnemyState();
    }

    private void SwitchToSpawnEnemyState()
    {
        controller.SwitchState<SpawnEnemyState>();
    }
}