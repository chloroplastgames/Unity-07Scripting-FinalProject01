using UnityEngine;

public class MainMenuState : State
{
    private readonly MainMenu canvas;
    private readonly GameObject cameraMainMenu;
    private readonly GameObject cameraGameplay;

    public MainMenuState(
        IStateController controller,
        MainMenu canvas,
        GameObject cameraMainMenu,
        GameObject cameraGameplay
        ) : base(controller)
    {
        this.canvas = canvas;
        this.cameraMainMenu = cameraMainMenu;
        this.cameraGameplay = cameraGameplay;
    }

    public override void Enter()
    {
        base.Enter();

        cameraGameplay.SetActive(false);
        cameraMainMenu.SetActive(true);
        canvas.gameObject.SetActive(true);

        canvas.ButtonPvsP.onClick.AddListener(() => SwitchToCharacterSelectionPvsPState());
        canvas.ButtonPvsCPU.onClick.AddListener(() => SwitchToCharacterSelectionPvsCPUState());
        canvas.ButtonExit.onClick.AddListener(() => ExitGame());
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

        canvas.gameObject.SetActive(false);

        canvas.ButtonPvsP.onClick.RemoveAllListeners();
        canvas.ButtonPvsCPU.onClick.RemoveAllListeners();
        canvas.ButtonExit.onClick.RemoveAllListeners();
    }

    private void SwitchToCharacterSelectionPvsPState()
    {
        controller.SwitchState<CharacterSelectionPvsPState>();
    }

    private void SwitchToCharacterSelectionPvsCPUState()
    {
        controller.SwitchState<CharacterSelectionPvsCPUSTate>();
    }

    private void ExitGame()
    {
        Debug.Log("Exit game...");
        Application.Quit();
    }
}