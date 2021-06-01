public class GameOverState : State
{
    private readonly CanvasGameOver gameOver;

    public GameOverState(
        IStateController controller,
        CanvasGameOver gameOver
        ) : base(controller)
    {
        this.gameOver = gameOver;
    }

    public override void Enter()
    {
        base.Enter();

        gameOver.gameObject.SetActive(true);

        gameOver.ButtonMenu.onClick.AddListener(() => SwitchToMainMenuState());
        gameOver.ButtonRestart.onClick.AddListener(() => SwitchToCountdownState());
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

        gameOver.gameObject.SetActive(false);

        gameOver.ButtonMenu.onClick.RemoveAllListeners();
        gameOver.ButtonRestart.onClick.RemoveAllListeners();
    }

    private void SwitchToMainMenuState()
    {
        controller.SwitchState<MainMenuState>();
    }

    private void SwitchToCountdownState()
    {
        controller.SwitchState<CountdownState>();
    }
}