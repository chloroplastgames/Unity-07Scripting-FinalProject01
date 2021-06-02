public class SpawnEnemyState : State
{
    public SpawnEnemyState(
        IStateController controller
        ) : base(controller)
    {

    }

    public override void Enter()
    {
        base.Enter();

        CoroutinesHelperSingleton.Instance.WaitForSeconds(0.25f, () => SwitchToChaseEnemyState());
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

    private void SwitchToChaseEnemyState()
    {
        controller.SwitchState<ChaseEnemyState>();
    }

    private void SwitchToDeadEnemyState()
    {
        controller.SwitchState<DeadEnemyState>();
    }
}