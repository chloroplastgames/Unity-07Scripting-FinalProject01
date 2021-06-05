public class DeadPlayerState : State
{
    public DeadPlayerState(
        IStateController controller
        ) : base(controller)
    {

    }

    public override void Enter()
    {
        base.Enter();
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
    }

    private void SwitchToAlivePlayerState()
    {
        controller.SwitchState<AlivePlayerState>();
    }
}