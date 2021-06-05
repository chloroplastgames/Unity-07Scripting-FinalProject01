// TODO: Observe end round event

public abstract class AliveEnemyStateBase : State
{
    protected AliveEnemyStateBase(
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

    private void SwitchToDeadEnemyState()
    {
        controller.SwitchState<DeadEnemyState>();
    } 
}