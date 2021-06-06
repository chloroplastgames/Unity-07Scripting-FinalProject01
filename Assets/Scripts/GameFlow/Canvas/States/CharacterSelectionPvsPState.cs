public class CharacterSelectionPvsPState : State, IObserver<SetupGameEventArgs>
{
    private readonly ICharacterSelectionPvsP characterSelectionPvsP;
    private readonly GameController gameController;

    public CharacterSelectionPvsPState(
        IStateController controller,
        ICharacterSelectionPvsP characterSelectionPvsP,
        GameController gameController
        ) : base(controller)
    {
        this.characterSelectionPvsP = characterSelectionPvsP;
        this.gameController = gameController;
    }

    public override void Enter()
    {
        base.Enter();

        gameController.SetupGameSubject.Add(this);

        characterSelectionPvsP.CanvasCharacterSelectionPvsP.SetActive(true);
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

        gameController.SetupGameSubject.Remove(this);

        characterSelectionPvsP.CanvasCharacterSelectionPvsP.SetActive(false);

        characterSelectionPvsP.ResetPlayer1Selection();
        characterSelectionPvsP.ResetPlayer2Selection();
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