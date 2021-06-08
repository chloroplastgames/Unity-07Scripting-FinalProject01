using UnityEngine;

public class PvsCPUState : State, IObserver<Player1CharacterSelectionEventArgs>, IObserver<CancelEventArgs>
{
    private readonly ICharacterSelectionPvsCPUEvents characterSelectionPvsCPUEvents;
    private readonly GameController gameController;

    public PvsCPUState(
        IStateController controller,
        ICharacterSelectionPvsCPUEvents characterSelectionPvsCPUEvents,
        GameController gameController
        ) : base(controller)
    {
        this.characterSelectionPvsCPUEvents = characterSelectionPvsCPUEvents;
        this.gameController = gameController;
    }

    public override void Enter()
    {
        base.Enter();

        characterSelectionPvsCPUEvents.Player1CharacterSelectorSubject.Add(this);
        characterSelectionPvsCPUEvents.CancelCharacterSelectionSubject.Add(this);
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

        characterSelectionPvsCPUEvents.Player1CharacterSelectorSubject.Remove(this);
        characterSelectionPvsCPUEvents.CancelCharacterSelectionSubject.Remove(this);
    }

    public void OnNotify(Player1CharacterSelectionEventArgs player1CharacterSelectionArgs)
    {
        gameController.SetAgent1Color(player1CharacterSelectionArgs.player1Color);
        gameController.SetAgent2Color(Color.black);
    }

    public void OnNotify(CancelEventArgs parameter)
    {
        SwitchToStartState();
    }

    private void SwitchToStartState()
    {
        controller.SwitchState<StartState>();
    }
}