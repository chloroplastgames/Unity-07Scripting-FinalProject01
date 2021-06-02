public class GameOverState : State
{
    private readonly CanvasGameOver gameOver;
    private readonly IShowWinner winnerShower;

    public GameOverState(
        IStateController controller,
        CanvasGameOver gameOver,
        IShowWinner winnerShower
        ) : base(controller)
    {
        this.gameOver = gameOver;
        this.winnerShower = winnerShower;
    }

    public override void Enter()
    {
        base.Enter();

        gameOver.gameObject.SetActive(true);

        winnerShower.ShowWinner();

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
        GameManagerSingleton.Instance.ResetGameHard();

        controller.SwitchState<MainMenuState>();
    }

    private void SwitchToCountdownState()
    {
        GameManagerSingleton.Instance.ResetGameSoft();

        controller.SwitchState<CountdownState>();
    }
}