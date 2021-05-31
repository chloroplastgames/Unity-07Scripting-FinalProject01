public class GameOverState : State
{
    private readonly GameOver canvas;

    public GameOverState(
        IStateController controller,
        GameOver canvas
        ) : base(controller)
    {
        this.canvas = canvas;
    }

    public override void Enter()
    {
        base.Enter();

        canvas.gameObject.SetActive(true);

        canvas.ButtonMenu.onClick.AddListener(() => SwitchToMainMenuState());
        canvas.ButtonRestart.onClick.AddListener(() => SwitchToCountdownState());
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

        canvas.gameObject.SetActive(false);

        canvas.ButtonMenu.onClick.RemoveAllListeners();
        canvas.ButtonRestart.onClick.RemoveAllListeners();
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