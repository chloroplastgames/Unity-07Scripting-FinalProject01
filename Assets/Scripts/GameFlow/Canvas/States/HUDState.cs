public class HUDState : State, IObserver<GameWinnerEventArgs>
{
    private readonly IHUD hud;
    private readonly GameController gameController;

    public HUDState(
        IStateController controller,
        IHUD hud,
        GameController gameController
        ) : base(controller)
    {
        this.hud = hud;
        this.gameController = gameController;
    }

    public override void Enter()
    {
        gameController.GameWinnerSubject.Add(this);

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
        gameController.GameWinnerSubject.Remove(this);

        hud.CanvasHUD.SetActive(false);

        hud.StopTimer();
    }

    public void OnNotify(GameWinnerEventArgs gameWinnerEventArgs)
    {
        if (gameWinnerEventArgs.gameWinner.instance == null)
        {
            SwitchToCountdownState();
        }
        else
        {
            SwitchToGameOverState();
        }
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