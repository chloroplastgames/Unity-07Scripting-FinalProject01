// TODO: Observe start round event

public class DeadEnemyState : State
{
    public DeadEnemyState(
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

    private void SwitchToSpawnEnemyState()
    {
        controller.SwitchState<SpawnEnemyState>();
    }
}