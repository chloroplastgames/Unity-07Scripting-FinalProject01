using UnityEngine;

public class ActivePlayerState : State, IObserver
{
    private readonly ITranslate translator;
    private readonly IRotate rotator;
    private readonly IShoot shooter;
    private readonly ISubject killerSubject;

    private float translationSense;
    private float rotationSense;

    public ActivePlayerState(
        IStateController controller,
        ITranslate translator,
        IRotate rotator,
        IShoot shooter,
        ISubject killerSubject
        ) : base(controller)
    {
        this.translator = translator;
        this.rotator = rotator;
        this.shooter = shooter;
        this.killerSubject = killerSubject;
    }

    public override void Enter()
    {
        base.Enter();

        killerSubject.Add(this);
    }

    public override void Update()
    {
        translationSense = Input.GetAxis("Vertical1");
        rotationSense = Input.GetAxis("Horizontal1");

        if (Input.GetKeyDown(KeyCode.B))
        {
            shooter.Shoot();
        }
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