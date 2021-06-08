public class StartState : State, IObserver<ButtonPvsPEventArgs>, IObserver<ButtonPvsCPUEventArgs>
{
    private readonly IMainMenuEvents mainMenuEvents;
    private readonly GameController gameController;

    public StartState(
        IStateController controller,
        IMainMenuEvents mainMenuEvents,
        GameController gameController
        ) : base(controller)
    {
        this.mainMenuEvents = mainMenuEvents;
        this.gameController = gameController;
    }

    public override void Enter()
    {
        base.Enter();

        mainMenuEvents.ButtonPvsPSubject.Add(this);
        mainMenuEvents.ButtonPvsCPUSubject.Add(this);
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

        mainMenuEvents.ButtonPvsPSubject.Remove(this);
        mainMenuEvents.ButtonPvsCPUSubject.Remove(this);
    }

    public void OnNotify(ButtonPvsPEventArgs buttonPvsPArgs)
    {
        gameController.SetAgents(buttonPvsPArgs.agent1, buttonPvsPArgs.agent2);

        SwitchToPvsPState();
    }

    public void OnNotify(ButtonPvsCPUEventArgs buttonPvsCPUArgs)
    {
        gameController.SetAgents(buttonPvsCPUArgs.agent1, buttonPvsCPUArgs.agent2);

        SwitchToPvsCPUState();
    }

    private void SwitchToPvsPState()
    {
        controller.SwitchState<PvsPState>();
    }

    private void SwitchToPvsCPUState()
    {
        controller.SwitchState<PvsCPUState>();
    }
}