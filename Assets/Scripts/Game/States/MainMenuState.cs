using UnityEngine;

public class MainMenuState : State, IObserver<ButtonPvsPArgs>, IObserver<ButtonPvsCPUArgs>
{
    private readonly IMainMenu mainMenu;
    private readonly GameObject cameraMainMenu;
    private readonly GameObject cameraGameplay;

    public MainMenuState(
        IStateController controller,
        IMainMenu mainMenu,
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

        cameraMainMenu.SetActive(true);
        cameraGameplay.SetActive(false);
        mainMenu.CanvasMainMenu.SetActive(true);

        mainMenu.ButtonPvsPSubject.Add(this);
        mainMenu.ButtonPvsCPUSubject.Add(this);
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

        mainMenu.CanvasMainMenu.SetActive(false);

        mainMenu.ButtonPvsPSubject.Remove(this);
        mainMenu.ButtonPvsCPUSubject.Remove(this);
    }

    public void OnNotify(ButtonPvsPArgs parameter)
    {
        SwitchToCharacterSelectionPvsPState();
    }

    public void OnNotify(ButtonPvsCPUArgs parameter)
    {
        SwitchToCharacterSelectionPvsCPUState();
    }

    private void SwitchToCharacterSelectionPvsPState()
    {
        controller.SwitchState<CharacterSelectionPvsPState>();
    }

    private void SwitchToCharacterSelectionPvsCPUState()
    {
        controller.SwitchState<CharacterSelectionPvsCPUSTate>();
    }
}