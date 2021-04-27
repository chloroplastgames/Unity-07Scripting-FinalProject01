public class PlayerStateController : StateController
{
    private void Awake()
    {
        ITranslate translator = GetComponent<ITranslate>();
        IRotate rotator = GetComponent<IRotate>();
        IFire shooter = GetComponent<IFire>();
        ISubject dieBehaviour = GetComponent<DieBehaviour>(); // TODO

        IState activePlayerState = new ActivePlayerState(
            this,
            translator,
            rotator,
            shooter,
            dieBehaviour
            );
        IState inactivePlayerState = new InactivePlayerState(
            this,
            gameObject
            );
        states.Add(typeof(ActivePlayerState), activePlayerState);
        states.Add(typeof(InactivePlayerState), inactivePlayerState);
    }

    private void Start()
    {
        SwitchState<ActivePlayerState>();
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