using UnityEngine;

public class ActivePlayerState : State, IObserver
{
    private readonly ITranslate translator;
    private readonly IRotate rotator;
    private readonly IShoot shooter;
    private readonly ISubject killerSubject;
    private readonly PlayerControlData control;

    private float translationSense;
    private float rotationSense;

    public ActivePlayerState(
        IStateController controller,
        ITranslate translator,
        IRotate rotator,
        IShoot shooter,
        ISubject killerSubject,
        PlayerControlData control
        ) : base(controller)
    {
        this.translator = translator;
        this.rotator = rotator;
        this.shooter = shooter;
        this.killerSubject = killerSubject;
        this.control = control;
    }

    public override void Enter()
    {
        base.Enter();

        killerSubject.Add(this);
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

        killerSubject.Remove(this);
    }

    public void OnNotify()
    {
        controller.SwitchState<InactivePlayerState>();
    }
}