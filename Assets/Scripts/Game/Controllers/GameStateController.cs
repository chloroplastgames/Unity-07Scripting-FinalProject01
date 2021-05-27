public class GameStateController : StateController
{
    private void Awake()
    {
        IState activeGameState = new ActiveGameState(
            this
            );
        states.Add(typeof(ActiveGameState), activeGameState);
    }

    private void Start()
    {
        SwitchState<ActiveGameState>();
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