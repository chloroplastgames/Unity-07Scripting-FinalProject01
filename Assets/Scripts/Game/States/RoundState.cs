using UnityEngine;

public class RoundState : State
{
    private readonly GameObject canvasHUD;

    public RoundState(
        IStateController controller,
        GameObject canvasHUD
        ) : base(controller)
    {
        this.canvasHUD = canvasHUD;
    }

    public override void Enter()
    {
        base.Enter();

        canvasHUD.SetActive(true);

        RoutineHelperSingleton.Instance.WaitForSeconds(5f, () => SwitchToGameOverState());
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

        canvasHUD.SetActive(false);
    }

    private void SwitchToGameOverState()
    {
        controller.SwitchState<GameOverState>();
    }
}