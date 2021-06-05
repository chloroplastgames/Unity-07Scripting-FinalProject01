﻿public class GameOverState : State, IObserver<ButtonRestartEventArgs>
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
        base.Enter();

        gameOver.ButtonRestartSubject.Add(this);

        gameOver.CanvasGameOver.SetActive(true);

        gameOver.ShowWinner();        
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