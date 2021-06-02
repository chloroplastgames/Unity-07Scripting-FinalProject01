using UnityEngine;

public class CharacterSelectionPvsCPUSTate : State
{
    private readonly GameObject canvas;
    private readonly IPlayerCharacterSelection playerCharacterSelector;
    private readonly PlayerControlData player1Control;

    private bool routineStarted;

    public CharacterSelectionPvsCPUSTate(
        IStateController controller,
        GameObject canvas,
        IPlayerCharacterSelection playerCharacterSelector,
        PlayerControlData player1Control
        ) : base(controller)
    {
        this.canvas = canvas;
        this.playerCharacterSelector = playerCharacterSelector;
        this.player1Control = player1Control;
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

        GetPlayerInput();
    }

    public override void FixedUpdate()
    {
        return;
    }

    public override void Exit()
    {
        base.Exit();

        canvas.SetActive(false);

        playerCharacterSelector.ResetSelection();

        GameManagerSingleton.Instance.SetupGame();
    }

    private void SwitchToCountdownState()
    {
        controller.SwitchState<CountdownState>();
    }

    private void SwitchToMainMenuState()
    {
        controller.SwitchState<MainMenuState>();
    }

    private void GetPlayerInput()
    {
        if (Input.GetKeyDown(player1Control.TurnLeft))
        {
            playerCharacterSelector.PreviousSelection();
        }
        else if (Input.GetKeyDown(player1Control.TurnRight))
        {
            playerCharacterSelector.NextSelection();
        }
        else if (Input.GetKeyDown(player1Control.Shoot))
        {
            playerCharacterSelector.SetSelection();

            CoroutinesHelperSingleton.Instance.WaitForSeconds(1f, () => SwitchToCountdownState());

            routineStarted = true;
        }
        else if (Input.GetKeyDown(player1Control.Special))
        {
            SwitchToMainMenuState();
        }  
    }
}