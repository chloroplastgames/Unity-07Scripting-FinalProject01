// TODO: Switch to Countdown state with SetupGameEvent

public class CharacterSelectionPvsPState : State, IObserver<Player1CharacterSelectionEventArgs>, IObserver<Player2CharacterSelectionEventArgs>
{
    private readonly ICharacterSelectionPvsP characterSelectionPvsP;

    private bool player1Ready;
    private bool player2Ready;

    public CharacterSelectionPvsPState(
        IStateController controller,
        ICharacterSelectionPvsP characterSelectionPvsP
        ) : base(controller)
    {
        this.characterSelectionPvsP = characterSelectionPvsP;
    }

    public override void Enter()
    {
        base.Enter();

        characterSelectionPvsP.Player1CharacterSelectorSubject.Add(this);
        characterSelectionPvsP.Player2CharacterSelectorSubject.Add(this);

        characterSelectionPvsP.CanvasCharacterSelectionPvsP.SetActive(true);

        player1Ready = false;
        player2Ready = false;
    }

    public override void Update()
    {
        characterSelectionPvsP.GetPlayer1Input();

        characterSelectionPvsP.GetPlayer2Input();
    }

    public override void FixedUpdate()
    {
        return;
    }

    public override void Exit()
    {
        base.Exit();

        characterSelectionPvsP.Player1CharacterSelectorSubject.Remove(this);
        characterSelectionPvsP.Player2CharacterSelectorSubject.Remove(this);

        characterSelectionPvsP.CanvasCharacterSelectionPvsP.SetActive(false);

        characterSelectionPvsP.ResetPlayer1Selection();
        characterSelectionPvsP.ResetPlayer2Selection();
    }

    public void OnNotify(Player1CharacterSelectionEventArgs parameter)
    {
        player1Ready = true;

        if (player2Ready)
        {
            SwitchToCountdownState();
        }
    }

    public void OnNotify(Player2CharacterSelectionEventArgs parameter)
    {
        player2Ready = true;

        if (player1Ready)
        {
            SwitchToCountdownState();
        }
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