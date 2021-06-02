using UnityEngine;

public class MainMenuState : State
{
    private readonly CanvasMainMenu mainMenu;
    private readonly GameObject cameraMainMenu;
    private readonly GameObject cameraGameplay;

    public MainMenuState(
        IStateController controller,
        CanvasMainMenu mainMenu,
        GameObject cameraMainMenu,
        GameObject cameraGameplay
        ) : base(controller)
    {
        this.mainMenu = mainMenu;
        this.cameraMainMenu = cameraMainMenu;
        this.cameraGameplay = cameraGameplay;
    }

    public override void Enter()
    {
        base.Enter();

        cameraGameplay.SetActive(false);
        cameraMainMenu.SetActive(true);
        mainMenu.gameObject.SetActive(true);

        mainMenu.ButtonPvsP.onClick.AddListener(() => SelectPvsP());
        mainMenu.ButtonPvsCPU.onClick.AddListener(() => SelectPvsCPU());
        mainMenu.ButtonExit.onClick.AddListener(() => ExitGame());
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

        mainMenu.gameObject.SetActive(false);

        mainMenu.ButtonPvsP.onClick.RemoveAllListeners();
        mainMenu.ButtonPvsCPU.onClick.RemoveAllListeners();
        mainMenu.ButtonExit.onClick.RemoveAllListeners();
    }

    private void SelectPvsP()
    {
        GameManagerSingleton.Instance.SetPvsP();

        controller.SwitchState<CharacterSelectionPvsPState>();
    }

    private void SelectPvsCPU()
    {
        GameManagerSingleton.Instance.SetPvsCPU();

        controller.SwitchState<CharacterSelectionPvsCPUSTate>();
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}