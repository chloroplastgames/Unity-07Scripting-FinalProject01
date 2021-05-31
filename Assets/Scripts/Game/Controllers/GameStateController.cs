using UnityEngine;

public class GameStateController : StateController
{
    [SerializeField] private GameObject cameraMainMenu;
    [SerializeField] private GameObject cameraGameplay;
    [SerializeField] private MainMenu canvasMainMenu;
    [SerializeField] private CharacterSelectionPvsP canvasCharacterSelectionPvsP;
    [SerializeField] private CharacterSelectionPvsCPU canvasCharacterSelectionPvsCPU;
    [SerializeField] private Countdown canvasCountdown;
    [SerializeField] private GameObject canvasHUD;
    [SerializeField] private GameOver canvasGameOver;

    private void Awake()
    {
        IState mainMenuState = new MainMenuState(
            this,
            canvasMainMenu,
            cameraMainMenu,
            cameraGameplay
            );
        IState characterSelectionPvsPState = new CharacterSelectionPvsPState(
            this,
             canvasCharacterSelectionPvsP
            );
        IState characterSelectionPvsCPUState = new CharacterSelectionPvsCPUSTate(
            this,
            canvasCharacterSelectionPvsCPU
            );
        IState countdownState = new CountdownState(
            this,
            canvasCountdown,
            cameraGameplay,
            cameraMainMenu
            );
        IState roundState = new RoundState(
            this,
            canvasHUD
            );
        IState gameOverState = new GameOverState(
            this,
            canvasGameOver
            );
        states.Add(typeof(MainMenuState), mainMenuState);
        states.Add(typeof(CharacterSelectionPvsPState), characterSelectionPvsPState);
        states.Add(typeof(CharacterSelectionPvsCPUSTate), characterSelectionPvsCPUState);
        states.Add(typeof(CountdownState), countdownState);
        states.Add(typeof(RoundState), roundState);
        states.Add(typeof(GameOverState), gameOverState);
    }

    private void Start()
    {
        SwitchState<MainMenuState>();
    }

    private void Update()
    {
        currentState.Update();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }
}