public class CharacterSelectionPvsCPUSTate : State, IObserver<SetupGameEventArgs>, IObserver<CancelEventArgs>
{
    private readonly ICharacterSelectionPvsCPU characterSelectionPvsCPU;
    private readonly GameController gameController;

    public CharacterSelectionPvsCPUSTate(
        IStateController controller,
        ICharacterSelectionPvsCPU characterSelectionPvsCPU,
        GameController gameController
        ) : base(controller)
    {
        this.characterSelectionPvsCPU = characterSelectionPvsCPU;
        this.gameController = gameController;
    }

    public override void Enter()
    {
        gameController.SetupGameSubject.Add(this);
        characterSelectionPvsCPU.CancelCharacterSelectionSubject.Add(this);

        characterSelectionPvsCPU.CanvasCharacterSelectionPvsCPU.SetActive(true);
    }

    public override void Update()
    {
        characterSelectionPvsCPU.GetPlayer1Input();
    }

    public override void FixedUpdate()
    {
        return;
    }

    public override void Exit()
    {
        gameController.SetupGameSubject.Remove(this);
        characterSelectionPvsCPU.CancelCharacterSelectionSubject.Remove(this);

        characterSelectionPvsCPU.CanvasCharacterSelectionPvsCPU.SetActive(false);

        characterSelectionPvsCPU.ResetPlayer1Selection();
    }

    public void OnNotify(SetupGameEventArgs parameter)
    {
        SwitchToCountdownState();
    }

    public void OnNotify(CancelEventArgs parameter)
    {
        SwitchToMainMenuState();
    }

    private void SwitchToCountdownState()
    {
        controller.SwitchState<CountdownState>();
    }

    private void SwitchToMainMenuState()
    {
        controller.SwitchState<MainMenuState>();
    }
}