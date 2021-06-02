using UnityEngine;

public class RoundState : State, IObserver<TimerArgs>
{
    private readonly GameObject canvas;
    private readonly TimerHUDBehaviour timer;

    public RoundState(
        IStateController controller,
        GameObject canvas,
        TimerHUDBehaviour timer
        ) : base(controller)
    {
        this.canvas = canvas;
        this.timer = timer;
    }

    public override void Enter()
    {
        base.Enter();

        canvas.SetActive(true);

        timer.Add(this);
        timer.ResetTimer();
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

        timer.Remove(this);
        timer.StopTimer();
    }

    public void OnNotify(TimerArgs parameter)
    {
        // Get tanks health

        // is last round => Game over
        // else => Countdown

        SwitchToCountdownState(); // TEST
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