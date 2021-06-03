using UnityEngine;

public class RoundState : State, IObserver<TimerArgs>, IObserver<DieArgs>
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

        GameManagerSingleton.Instance.Tank1Instance.GetComponent<ISubject<DieArgs>>().Add(this);
        GameManagerSingleton.Instance.Tank2Instance.GetComponent<ISubject<DieArgs>>().Add(this);

        GameManagerSingleton.Instance.StartRound();
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

        GameManagerSingleton.Instance.Tank1Instance.GetComponent<ISubject<DieArgs>>().Remove(this);
        GameManagerSingleton.Instance.Tank2Instance.GetComponent<ISubject<DieArgs>>().Remove(this);
    }

    public void OnNotify(TimerArgs timerArgs)
    {
        EndRound();

        CheckGameWinner();
    }

    public void OnNotify(DieArgs dieArgs)
    {
        EndRound();

        CheckGameWinner();
    }

    private void EndRound()
    {
        GameManagerSingleton.Instance.EndRound();
    }

    private void CheckGameWinner()
    {
        if (GameManagerSingleton.Instance.GameWinner == null)
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