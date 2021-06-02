using UnityEngine;

public class PlayerStateController : StateController
{
    [SerializeField] private PlayerControlData control;

    private void Awake()
    {
        ITranslate translator = GetComponent<ITranslate>();
        IRotate rotator = GetComponent<IRotate>();
        IShoot shooter = GetComponent<IShoot>();

        IState activePlayerState = new AlivePlayerState(
            this,
            translator,
            rotator,
            shooter,
            control
            );
        IState inactivePlayerState = new DeadPlayerState(
            this
            );
        states.Add(typeof(AlivePlayerState), activePlayerState);
        states.Add(typeof(DeadPlayerState), inactivePlayerState);
    }

    private void Start()
    {
        SwitchState<DeadPlayerState>();
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