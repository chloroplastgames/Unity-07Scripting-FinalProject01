public class RoundStateController : StateController
{
    private void Awake()
    {
        IState startRoundState = new StartRoundState(
            this
            );
        IState playRoundState = new PlayRoundState(
            this
            );
        IState endRoundState = new EndRoundState(
            this
            );
        states.Add(typeof(StartRoundState), startRoundState);
        states.Add(typeof(PlayRoundState), playRoundState);
        states.Add(typeof(EndRoundState), endRoundState);
    }

    private void Start()
    {
        SwitchState<StartRoundState>();
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