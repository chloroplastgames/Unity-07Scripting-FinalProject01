public abstract class AliveEnemyStateBase : State, IObserver<EndRoundArgs>
{
    protected AliveEnemyStateBase(IStateController controller) : base(controller)
    {

    }

    public override void Enter()
    {
        base.Enter();

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

        GameManagerSingleton.Instance.RoundEnder.Remove(this);
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