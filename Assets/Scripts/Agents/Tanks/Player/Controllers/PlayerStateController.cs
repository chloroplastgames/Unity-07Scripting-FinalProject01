using UnityEngine;

public class PlayerStateController : StateController
{
    [SerializeField] private PlayerControlData control;

    private void Awake()
    {
        ITranslate translator = GetComponent<ITranslate>();
        IRotate rotator = GetComponent<IRotate>();
        IShoot shooter = GetComponent<IShoot>();

        GameController gameController = FindObjectOfType<GameController>();

        IState alivePlayerState = new AlivePlayerState(
            this,
            translator,
            rotator,
            shooter,
            control
            );
        IState deadPlayerState = new DeadPlayerState(
            this,
            gameController
            );
        states.Add(typeof(AlivePlayerState), alivePlayerState);
        states.Add(typeof(DeadPlayerState), deadPlayerState);
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