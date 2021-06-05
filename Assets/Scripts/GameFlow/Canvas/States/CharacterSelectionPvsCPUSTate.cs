// TODO: Switch to Countdown state with SetupGameEvent

public class CharacterSelectionPvsCPUSTate : State, IObserver<Player1CharacterSelectionEventArgs>
{
    private readonly ICharacterSelectionPvsCPU characterSelectionPvsCPU;

    public CharacterSelectionPvsCPUSTate(
        IStateController controller,
        ICharacterSelectionPvsCPU characterSelectionPvsCPU
        ) : base(controller)
    {
        this.characterSelectionPvsCPU = characterSelectionPvsCPU;
    }

    public override void Enter()
    {
        base.Enter();

        characterSelectionPvsCPU.Player1CharacterSelectorSubject.Add(this);

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

        characterSelectionPvsCPU.Player1CharacterSelectorSubject.Remove(this);

        characterSelectionPvsCPU.CanvasCharacterSelectionPvsCPU.SetActive(true);

        characterSelectionPvsCPU.ResetPlayer1Selection();
    }

    public void OnNotify(Player1CharacterSelectionEventArgs parameter)
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