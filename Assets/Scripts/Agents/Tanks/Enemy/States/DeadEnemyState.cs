public class DeadEnemyState : State, IObserver<StartRoundArgs>
{
    public DeadEnemyState(
        IStateController controller
        ) : base(controller)
    {

    }

    public override void Enter()
    {
        base.Enter();

        GameManagerSingleton.Instance.RoundStarter.Add(this);
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

        GameManagerSingleton.Instance.RoundStarter.Remove(this);
    }

    public void OnNotify(StartRoundArgs parameter)
    {
        SwitchToSpawnEnemyState();
    }

    private void SwitchToSpawnEnemyState()
    {
        controller.SwitchState<SpawnEnemyState>();
    }
}