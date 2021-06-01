using UnityEngine;

public class GameStateController : StateController
{
    [SerializeField] private GameObject cameraMainMenuParent;
    [SerializeField] private GameObject cameraGameplayParent;
    [SerializeField] private CanvasMainMenu canvasMainMenu;
    [SerializeField] private GameObject canvasCharacterSelectionPvsP;
    [SerializeField] private GameObject canvasCharacterSelectionPvsCPU;
    [SerializeField] private CanvasCountdown canvasCountdown;
    [SerializeField] private GameObject canvasHUD;
    [SerializeField] private CanvasGameOver canvasGameOver;
    [SerializeField] private PlayerControlData player1Control;
    [SerializeField] private PlayerControlData player2Control;

    private void Awake()
    {
        IPlayerCharacterSelection player1CharacterSelectorPvsP =
            canvasCharacterSelectionPvsP.GetComponent<Player1CharacterSelectionBehaviour>();
        IPlayerCharacterSelection player2CharacterSelectorPvsP =
            canvasCharacterSelectionPvsP.GetComponent<Player2CharacterSelectionBehaviour>();
        IPlayerCharacterSelection playerCharacterSelectorPvsCPU =
            canvasCharacterSelectionPvsCPU.GetComponent<Player1CharacterSelectionBehaviour>();

        IState mainMenuState = new MainMenuState(
            this,
            canvasMainMenu,
            cameraMainMenuParent,
            cameraGameplayParent
            );
        IState characterSelectionPvsPState = new CharacterSelectionPvsPState(
            this,
            canvasCharacterSelectionPvsP,
            player1CharacterSelectorPvsP,
            player2CharacterSelectorPvsP,
            player1Control,
            player2Control
            );
        IState characterSelectionPvsCPUState = new CharacterSelectionPvsCPUSTate(
            this,
            canvasCharacterSelectionPvsCPU,
            playerCharacterSelectorPvsCPU,
            player1Control
            );
        IState countdownState = new CountdownState(
            this,
            canvasCountdown,
            cameraGameplayParent,
            cameraMainMenuParent
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