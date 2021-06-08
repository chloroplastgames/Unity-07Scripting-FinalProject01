using UnityEngine;

public class SpawnEnemyState : AliveEnemyStateBase
{
    private const float TimeToChase = 0.25f;

    private Coroutine chaseRoutine;

    public SpawnEnemyState(
        IStateController controller,
        GameController gameController
        ) : base(controller, gameController)
    {

    }

    public override void Enter()
    {
        base.Enter();

        chaseRoutine = CoroutinesHelperSingleton.Instance.WaitForSeconds(TimeToChase, () => SwitchToChaseEnemyState());
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