using UnityEngine;

public class SpawnEnemyState : AliveEnemyStateBase
{
    private Coroutine chaseRoutine;

    public SpawnEnemyState(
        IStateController controller
        ) : base(controller)
    {

    }

    public override void Enter()
    {
        base.Enter();

        chaseRoutine = CoroutinesHelperSingleton.Instance.WaitForSeconds(0.25f, () => SwitchToChaseEnemyState());
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

        CoroutinesHelperSingleton.Instance.StopCoroutine(chaseRoutine);
    }

    private void SwitchToChaseEnemyState()
    {
        controller.SwitchState<ChaseEnemyState>();
    }
}