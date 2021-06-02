// TODO: Event => ActivePlayerState

public class InactivePlayerState : State
{
    public InactivePlayerState(
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
}