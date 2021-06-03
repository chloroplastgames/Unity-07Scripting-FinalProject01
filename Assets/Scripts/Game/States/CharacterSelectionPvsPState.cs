using UnityEngine;

public class CharacterSelectionPvsPState : State
{
    private readonly GameObject canvas;
    private readonly IPlayerCharacterSelection player1CharacterSelector;
    private readonly IPlayerCharacterSelection player2CharacterSelector;
    private readonly PlayerControlData player1Control;
    private readonly PlayerControlData player2Control;

    private bool routineStarted;

    public CharacterSelectionPvsPState(
        IStateController controller,
        GameObject canvas,
        IPlayerCharacterSelection player1CharacterSelector,
        IPlayerCharacterSelection player2CharacterSelector,
        PlayerControlData player1Control,
        PlayerControlData player2Control
        ) : base(controller)
    {
        this.canvas = canvas;
        this.player1CharacterSelector = player1CharacterSelector;
        this.player2CharacterSelector = player2CharacterSelector;
        this.player1Control = player1Control;
        this.player2Control = player2Control;
    }

    public override void Enter()
    {
        base.Enter();

        routineStarted = false;

        canvas.SetActive(true);
    }

    public override void Update()
    {
        if (routineStarted) return;

        GetPlayer1Input();

        GetPlayer2Input();

        if (PlayersAreReady())
        {
            CoroutinesHelperSingleton.Instance.WaitForSeconds(1f, () => SwitchToCountdownState());

            routineStarted = true;
        }
    }

    public override void FixedUpdate()
    {
        return;
    }

    public override void Exit()
    {
        base.Exit();

        canvas.SetActive(false);

        player1CharacterSelector.ResetSelection();
        player2CharacterSelector.ResetSelection();
    }

    private bool PlayersAreReady()
    {
        return player1CharacterSelector.IsReady() && player2CharacterSelector.IsReady();
    }

    private void SwitchToCountdownState()
    {
        GameManagerSingleton.Instance.SetupGame();

        controller.SwitchState<CountdownState>();
    }

    private void SwitchToMainMenuState()
    {
        controller.SwitchState<MainMenuState>();
    }

    private void GetPlayer1Input()
    {
        if (Input.GetKeyDown(player1Control.TurnLeft))
        {
            player1CharacterSelector.PreviousSelection();
        }
        else if (Input.GetKeyDown(player1Control.TurnRight))
        {
            player1CharacterSelector.NextSelection();
        }
        else if (Input.GetKeyDown(player1Control.Shoot))
        {
            player1CharacterSelector.SetSelection();
        }
        else if (Input.GetKeyDown(player1Control.Special))
        {
            SwitchToMainMenuState();
        }
    }

    private void GetPlayer2Input()
    {
        if (Input.GetKeyDown(player2Control.TurnLeft))
        {
            player2CharacterSelector.PreviousSelection();
        }
        else if (Input.GetKeyDown(player2Control.TurnRight))
        {
            player2CharacterSelector.NextSelection();
        }
        else if (Input.GetKeyDown(player2Control.Shoot))
        {
            player2CharacterSelector.SetSelection();
        }
    }
}