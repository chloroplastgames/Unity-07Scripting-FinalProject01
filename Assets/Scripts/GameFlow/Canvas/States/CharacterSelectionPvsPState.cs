using UnityEngine;

public class CharacterSelectionPvsPState : State, IObserver<SetupGameEventArgs>, IObserver<CancelEventArgs>
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
        gameController.SetupGameSubject.Add(this);
        characterSelectionPvsP.CancelCharacterSelectionSubject.Add(this);

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
        gameController.SetupGameSubject.Remove(this);
        characterSelectionPvsP.CancelCharacterSelectionSubject.Remove(this);

        characterSelectionPvsP.CanvasCharacterSelectionPvsP.SetActive(false);

        characterSelectionPvsP.ResetPlayer1Selection();
        characterSelectionPvsP.ResetPlayer2Selection();
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