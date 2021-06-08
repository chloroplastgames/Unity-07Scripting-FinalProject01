public class GameStateController : StateController
{
    private void Awake()
    {
        GameController gameController = GetComponent<GameController>();

        IMainMenuEvents mainMenuEvents = FindObjectOfType<MainMenuController>();
        ICharacterSelectionPvsPEvents characterSelectionPvsPEvents = FindObjectOfType<CharacterSelectionPvsPController>();
        ICharacterSelectionPvsCPUEvents characterSelectionPvsCPUEvents = FindObjectOfType<CharacterSelectionPvsCPUController>();

        IState startState = new StartState(
            this,
            mainMenuEvents,
            gameController
            );
        IState pvspState = new PvsPState(
            this,
            characterSelectionPvsPEvents,
            gameController
            );
        IState pvscpuState = new PvsCPUState(
            this,
            characterSelectionPvsCPUEvents,
            gameController
            );
        states.Add(typeof(StartState), startState);
        states.Add(typeof(PvsPState), pvspState);
        states.Add(typeof(PvsCPUState), pvscpuState);
    }

    private void Start()
    {
        SwitchState<StartState>();
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