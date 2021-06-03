using UnityEngine;

public class AlivePlayerState : State, IObserver<EndRoundArgs>
{
    private readonly ITranslate translator;
    private readonly IRotate rotator;
    private readonly IShoot shooter;
    private readonly PlayerControlData control;

    private float translationSense;
    private float rotationSense;

    public AlivePlayerState(
        IStateController controller,
        ITranslate translator,
        IRotate rotator,
        IShoot shooter,
        PlayerControlData control
        ) : base(controller)
    {
        this.translator = translator;
        this.rotator = rotator;
        this.shooter = shooter;
        this.control = control;
    }

    public override void Enter()
    {
        base.Enter();

        GameManagerSingleton.Instance.RoundEnder.Add(this);
    }

    public override void Update()
    {
        if (Input.GetKey(control.Forward)) translationSense = 1f;
        else if (Input.GetKey(control.Backward)) translationSense = -1f;
        else translationSense = 0f;

        if (Input.GetKey(control.TurnRight)) rotationSense = 1f;
        else if (Input.GetKey(control.TurnLeft)) rotationSense = -1f;
        else rotationSense = 0f;

        if (Input.GetKeyDown(control.Shoot)) shooter.Shoot();
    }

    public override void FixedUpdate()
    {
        translator.Translate(translationSense);
        rotator.Rotate(rotationSense);
    }

    public override void Exit()
    {
        base.Exit();

        GameManagerSingleton.Instance.RoundEnder.Remove(this);
    }

    public void OnNotify(EndRoundArgs endRoundArgs)
    {
        SwitchToDeadPlayerState();
    }

    private void SwitchToDeadPlayerState()
    {
        controller.SwitchState<DeadPlayerState>();
    }
}