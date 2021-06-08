﻿using UnityEngine;

public class PvsPState : State, 
    IObserver<Player1CharacterSelectionEventArgs>, IObserver<Player2CharacterSelectionEventArgs>,
    IObserver<CancelEventArgs>
{
    private readonly ICharacterSelectionPvsPEvents characterSelectionPvsPEvents;
    private readonly GameController gameController;

    public PvsPState(
        IStateController controller,
        ICharacterSelectionPvsPEvents characterSelectionPvsPEvents,
        GameController gameController
        ) : base(controller)
    {
        this.characterSelectionPvsPEvents = characterSelectionPvsPEvents;
        this.gameController = gameController;
    }

    public override void Enter()
    {
        characterSelectionPvsPEvents.Player1CharacterSelectorSubject.Add(this);
        characterSelectionPvsPEvents.Player2CharacterSelectorSubject.Add(this);
        characterSelectionPvsPEvents.CancelCharacterSelectionSubject.Add(this);
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
        characterSelectionPvsPEvents.Player1CharacterSelectorSubject.Remove(this);
        characterSelectionPvsPEvents.Player2CharacterSelectorSubject.Remove(this);
        characterSelectionPvsPEvents.CancelCharacterSelectionSubject.Remove(this);
    }

    public void OnNotify(Player1CharacterSelectionEventArgs player1CharacterSelectionArgs)
    {
        gameController.SetAgent1Color(player1CharacterSelectionArgs.player1Color);
    }

    public void OnNotify(Player2CharacterSelectionEventArgs player2CharacterSelectionArgs)
    {
        gameController.SetAgent2Color(player2CharacterSelectionArgs.player2Color);
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