using UnityEngine;

public class RoundState : State
{
    private readonly GameObject canvas;

    public RoundState(
        IStateController controller,
        GameObject canvas
        ) : base(controller)
    {
        this.canvas = canvas;
    }

    public override void Enter()
    {
        base.Enter();

        canvas.SetActive(true);
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

        canvas.SetActive(false);
    }

    private void SwitchToGameOverState()
    {
        controller.SwitchState<GameOverState>();
    }
}