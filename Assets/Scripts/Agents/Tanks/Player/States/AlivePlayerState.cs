using UnityEngine;

public class AlivePlayerState : State, IObserver<EndRoundArgs>, IObserver<TimerArgs>
{
    private readonly ITranslate translator;
    private readonly IRotate rotator;
    private readonly IShoot shooter;
    private readonly PlayerControlData control;
    private readonly IHUDEvents hudEvents;
    private float translationSense;
    private float rotationSense;

    public AlivePlayerState(
        IStateController controller,
        ITranslate translator,
        IRotate rotator,
        IShoot shooter,
        PlayerControlData control,
        IHUDEvents hudEvents
        ) : base(controller)
    {
        this.translator = translator;
        this.rotator = rotator;
        this.shooter = shooter;
        this.control = control;
        this.hudEvents = hudEvents;
    }

    public override void Enter()
    {
        base.Enter();

        hudEvents.TimerSubject.Add(this);

        GameManagerSingleton.Instance.RoundEnder.Add(this); // TODO
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

        hudEvents.TimerSubject.Remove(this);

        GameManagerSingleton.Instance.RoundEnder.Remove(this); // TODO
    }

    public void OnNotify(TimerArgs parameter)
    {
        SwitchToDeadPlayerState();
    }

    public void OnNotify(EndRoundArgs endRoundArgs) // TODO
    {
        SwitchToDeadPlayerState();
    }

    private void SwitchToDeadPlayerState()
    {
        controller.SwitchState<DeadPlayerState>();
    }
}