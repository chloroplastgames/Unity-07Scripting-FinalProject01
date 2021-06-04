using UnityEngine;

public class GameStateController : StateController
{
    [SerializeField] private GameObject cameraMainMenu;
    [SerializeField] private GameObject cameraGameplay;
    [SerializeField] private GameObject canvasHUD;
    [SerializeField] private TimerHUDBehaviour timerHUDBehaviour;
    [SerializeField] private CanvasGameOver canvasGameOver;

    private void Awake()
    {
        IMainMenu mainMenu = FindObjectOfType<MainMenuController>();
        ICharacterSelectionPvsP characterSelectionPvsP = FindObjectOfType<CharacterSelectionPvsPController>();
        ICharacterSelectionPvsCPU characterSelectionPvsCPU = FindObjectOfType<CharacterSelectionPvsCPUController>();
        ICountdown countdown = FindObjectOfType<CountdownController>();

        IShowWinner winnerShower =
            canvasGameOver.gameObject.GetComponent<IShowWinner>();

        IState mainMenuState = new MainMenuState(
            this,
            mainMenu,
            cameraMainMenu,
            cameraGameplay
            );
        IState characterSelectionPvsPState = new CharacterSelectionPvsPState(
            this,
            characterSelectionPvsP
            );
        IState characterSelectionPvsCPUState = new CharacterSelectionPvsCPUSTate(
            this,
            characterSelectionPvsCPU
            );
        IState countdownState = new CountdownState(
            this,
            countdown,
            cameraGameplay,
            cameraMainMenu
            );
        IState roundState = new RoundState(
            this,
            canvasHUD,
            timerHUDBehaviour
            );
        IState gameOverState = new GameOverState(
            this,
            canvasGameOver,
            winnerShower
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