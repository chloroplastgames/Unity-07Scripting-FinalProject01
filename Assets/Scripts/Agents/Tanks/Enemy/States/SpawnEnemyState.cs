using UnityEngine;

public class SpawnEnemyState : State
{
    public SpawnEnemyState(IStateController controller) : base(controller) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        // TEST - Should wait .25f seconds
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.SwitchState<ChaseEnemyState>();
        }
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