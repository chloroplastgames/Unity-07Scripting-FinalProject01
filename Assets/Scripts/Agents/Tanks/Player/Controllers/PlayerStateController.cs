using UnityEngine;

public class PlayerStateController : StateController
{
    [SerializeField] private PlayerControlData control;

    private void Awake()
    {
        ITranslate translator = GetComponent<ITranslate>();
        IRotate rotator = GetComponent<IRotate>();
        IShoot shooter = GetComponent<IShoot>();
        ISubject<DieArgs> dieBehaviour = GetComponent<ISubject<DieArgs>>();

        IState activePlayerState = new ActivePlayerState(
            this,
            translator,
            rotator,
            shooter,
            dieBehaviour,
            control
            );
        IState inactivePlayerState = new InactivePlayerState(
            this
            );
        states.Add(typeof(ActivePlayerState), activePlayerState);
        states.Add(typeof(InactivePlayerState), inactivePlayerState);
    }

    private void Start()
    {
        SwitchState<ActivePlayerState>(); // TODO: Change to InactivePlayerState
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