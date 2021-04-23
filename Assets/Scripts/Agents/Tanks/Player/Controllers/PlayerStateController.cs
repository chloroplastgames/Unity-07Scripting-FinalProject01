public class PlayerStateController : StateController
{
    private IState activePlayerState;
    private IState inactivePlayerState;

    private ITranslate translator;
    private IRotate rotator;
    private IFire shooter;
    private ISubject dieBehaviour;

    private void Awake()
    {
        translator = GetComponent<ITranslate>();
        rotator = GetComponent<IRotate>();
        shooter = GetComponent<IFire>();
        dieBehaviour = GetComponent<DieBehaviour>(); // TODO

        activePlayerState = new ActivePlayerState(
            this,
            translator,
            rotator,
            shooter,
            dieBehaviour
            );
        inactivePlayerState = new InactivePlayerState(
            this
            );
        states.Add(typeof(ActivePlayerState), activePlayerState);
        states.Add(typeof(InactivePlayerState), inactivePlayerState);
    }

    private void Start()
    {
        SwitchState<InactivePlayerState>();
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