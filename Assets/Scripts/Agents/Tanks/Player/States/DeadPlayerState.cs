public class DeadPlayerState : State, IObserver<StartRoundArgs>
{
    public DeadPlayerState(
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

    public void OnNotify(StartRoundArgs startRoundArgs)
    {
        SwitchToAlivePlayerState();
    }

    private void SwitchToAlivePlayerState()
    {
        controller.SwitchState<AlivePlayerState>();
    }
}