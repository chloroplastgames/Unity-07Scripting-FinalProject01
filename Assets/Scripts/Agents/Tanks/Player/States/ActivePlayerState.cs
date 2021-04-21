using UnityEngine;

public class ActivePlayerState : State
{
    private readonly ITranslate translator;
    private readonly IRotate rotator;
    private readonly IFire shooter;

    private float translationSense;
    private float rotationSense;

    public ActivePlayerState(
        IStateController controller,
        ITranslate translator,
        IRotate rotator,
        IFire shooter
        ) : base(controller)
    {
        this.translator = translator;
        this.rotator = rotator;
        this.shooter = shooter;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        translationSense = Input.GetAxis("Vertical1");
        rotationSense = Input.GetAxis("Horizontal1");

        if (Input.GetKeyDown(KeyCode.B))
        {
            shooter.Fire();
        }

        // TEST
        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.SwitchState<InactivePlayerState>();
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
    }
}