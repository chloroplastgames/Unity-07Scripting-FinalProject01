using UnityEngine;

public class InactivePlayerState : State
{
    public InactivePlayerState(IStateController controller) : base(controller) { }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        // TEST
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.SwitchState<ActivePlayerState>();
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