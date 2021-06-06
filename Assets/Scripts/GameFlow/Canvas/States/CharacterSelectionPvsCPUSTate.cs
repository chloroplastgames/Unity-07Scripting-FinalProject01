public class CharacterSelectionPvsCPUSTate : State, IObserver<SetupGameEventArgs>
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
        base.Enter();

        gameController.SetupGameSubject.Add(this);

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
        base.Exit();

        gameController.SetupGameSubject.Remove(this);

        characterSelectionPvsCPU.CanvasCharacterSelectionPvsCPU.SetActive(true);

        characterSelectionPvsCPU.ResetPlayer1Selection();
    }

    public void OnNotify(SetupGameEventArgs parameter)
    {
        SwitchToCountdownState();
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