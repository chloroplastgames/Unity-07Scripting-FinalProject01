using UnityEngine;

/// <summary>
/// State that controls player
/// </summary>

public class AlivePlayerState : State, IObserver<EndRoundEventArgs>
{
    private readonly ITranslate translator;
    private readonly IRotate rotator;
    private readonly IShoot shooter;
    private readonly PlayerControlData control;
    private readonly GameController gameController;
    private readonly IConsumePowerUp powerUpConsumer;
    private float translationSense;
    private float rotationSense;

    public AlivePlayerState(
        IStateController controller,
        ITranslate translator,
        IRotate rotator,
        IShoot shooter,
        PlayerControlData control,
        GameController gameController,
        IConsumePowerUp powerUpConsumer
        ) : base(controller)
    {
        this.translator = translator;
        this.rotator = rotator;
        this.shooter = shooter;
        this.control = control;
        this.gameController = gameController;
        this.powerUpConsumer = powerUpConsumer;
    }

    public override void Enter()
    {
        gameController.EndRoundSubject.Add(this);
    }

    public override void Update()
    {
        if (Input.GetKey(control.Forward)) translationSense = 1f;
        else if (Input.GetKey(control.Backward)) translationSense = -1f;
        else translationSense = 0f;

        if (Input.GetKey(control.TurnRight)) rotationSense = 1f;
        else if (Input.GetKey(control.TurnLeft)) rotationSense = -1f;
        else rotationSense = 0f;

        // Shooter has input controller
        shooter.Shoot();

        if (Input.GetKey(control.Special))
        {
            powerUpConsumer.ConsumePowerUp();
        }
    }

    public override void FixedUpdate()
    {
        translator.Translate(translationSense);
        rotator.Rotate(rotationSense);
    }

    public override void Exit()
    {
        gameController.EndRoundSubject.Add(this);
    }

    public void OnNotify(EndRoundEventArgs parameter)
    {
        SwitchToDeadPlayerState();
    }

    private void SwitchToDeadPlayerState()
    {
        controller.SwitchState<DeadPlayerState>();
    }
}