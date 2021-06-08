using UnityEngine;

public class CanvasStateController : StateController
{
    [SerializeField] private GameObject cameraMainMenu;
    [SerializeField] private GameObject cameraGameplay;

    private void Awake()
    {
        IMainMenu mainMenu = FindObjectOfType<MainMenuController>();
        ICharacterSelectionPvsP characterSelectionPvsP = FindObjectOfType<CharacterSelectionPvsPController>();
        ICharacterSelectionPvsCPU characterSelectionPvsCPU = FindObjectOfType<CharacterSelectionPvsCPUController>();
        ICountdown countdown = FindObjectOfType<CountdownController>();
        IHUD hud = FindObjectOfType<HUDController>();
        IGameOver gameOver = FindObjectOfType<GameOverController>();

        GameController gameController = FindObjectOfType<GameController>();

        IState mainMenuState = new MainMenuState(
            this,
            mainMenu,
            cameraMainMenu,
            cameraGameplay
            );
        IState characterSelectionPvsPState = new CharacterSelectionPvsPState(
            this,
            characterSelectionPvsP,
            gameController
            );
        IState characterSelectionPvsCPUState = new CharacterSelectionPvsCPUSTate(
            this,
            characterSelectionPvsCPU,
            gameController
            );
        IState countdownState = new CountdownState(
            this,
            countdown,
            cameraGameplay,
            cameraMainMenu
            );
        IState roundState = new HUDState(
            this,
            hud,
            gameController
            );
        IState gameOverState = new GameOverState(
            this,
            gameOver
            );
        states.Add(typeof(MainMenuState), mainMenuState);
        states.Add(typeof(CharacterSelectionPvsPState), characterSelectionPvsPState);
        states.Add(typeof(CharacterSelectionPvsCPUSTate), characterSelectionPvsCPUState);
        states.Add(typeof(CountdownState), countdownState);
        states.Add(typeof(HUDState), roundState);
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