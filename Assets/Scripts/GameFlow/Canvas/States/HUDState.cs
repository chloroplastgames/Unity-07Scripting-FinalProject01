public class HUDState : State, IObserver<TimerArgs>, IObserver<DieArgs>
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

        hud.TimerSubject.Add(this);

        hud.CanvasHUD.SetActive(true);

        hud.ResetTimer();

        GameManagerSingleton.Instance.Agent1Instance.GetComponent<ISubject<DieArgs>>().Add(this); // TODO
        GameManagerSingleton.Instance.Agent2Instance.GetComponent<ISubject<DieArgs>>().Add(this); // TODO
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

        hud.TimerSubject.Remove(this);

        hud.CanvasHUD.SetActive(false);

        hud.StopTimer();

        GameManagerSingleton.Instance.Agent1Instance.GetComponent<ISubject<DieArgs>>().Remove(this); // TODO
        GameManagerSingleton.Instance.Agent2Instance.GetComponent<ISubject<DieArgs>>().Remove(this); // TODO
    }

    public void OnNotify(TimerArgs timerArgs) // TODO
    {
        CheckGameWinner();
    }

    public void OnNotify(DieArgs dieArgs) // TODO
    {
        CheckGameWinner();
    }

    private void CheckGameWinner() // TODO
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