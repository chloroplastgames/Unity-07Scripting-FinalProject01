public class GameOverState : State, IObserver<ButtonRestartEventArgs>
{
    private readonly IGameOver gameOver;

    public GameOverState(
        IStateController controller,
        IGameOver gameOver
        ) : base(controller)
    {
        this.gameOver = gameOver;
    }

    public override void Enter()
    {
        gameOver.ButtonRestartSubject.Add(this);

        gameOver.CanvasGameOver.SetActive(true);        
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
        gameOver.ButtonRestartSubject.Remove(this);

        gameOver.CanvasGameOver.SetActive(false);      
    }

    public void OnNotify(ButtonRestartEventArgs parameter)
    {
        SwitchToCountdownState();
    }

    private void SwitchToCountdownState()
    {
        controller.SwitchState<CountdownState>();
    }
}