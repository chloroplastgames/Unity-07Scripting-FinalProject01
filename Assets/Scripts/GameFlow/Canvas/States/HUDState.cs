// TODO: Switch to CountdownState or GameOverState with EndRoundEvent

public class HUDState : State
{
    private readonly IHUD hud;

    public HUDState(
        IStateController controller,
        IHUD hud
        ) : base(controller)
    {
        this.hud = hud;
    }

    public override void Enter()
    {
        base.Enter();

        hud.CanvasHUD.SetActive(true);

        hud.ResetTimer();
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

        hud.CanvasHUD.SetActive(false);

        hud.StopTimer();
    }

    private void SwitchToCountdownState()
    {
        controller.SwitchState<CountdownState>();
    }

    private void SwitchToGameOverState()
    {
        controller.SwitchState<GameOverState>();
    }
}