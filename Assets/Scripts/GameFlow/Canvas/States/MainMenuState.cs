using UnityEngine;

public class MainMenuState : State, IObserver<ButtonPvsPEventArgs>, IObserver<ButtonPvsCPUEventArgs>
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

        mainMenu.ButtonPvsPSubject.Add(this);
        mainMenu.ButtonPvsCPUSubject.Add(this);

        cameraMainMenu.SetActive(true);
        cameraGameplay.SetActive(false);
        mainMenu.CanvasMainMenu.SetActive(true);    
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

        mainMenu.ButtonPvsPSubject.Remove(this);
        mainMenu.ButtonPvsCPUSubject.Remove(this);

        mainMenu.CanvasMainMenu.SetActive(false);   
    }

    public void OnNotify(ButtonPvsPEventArgs parameter)
    {
        SwitchToCharacterSelectionPvsPState();
    }

    public void OnNotify(ButtonPvsCPUEventArgs parameter)
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