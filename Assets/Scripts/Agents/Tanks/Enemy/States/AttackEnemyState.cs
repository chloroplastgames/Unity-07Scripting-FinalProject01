public class AttackEnemyState : State, IObserver
{
    private readonly ISubject killerSubject;

    public AttackEnemyState(
        IStateController controller,
        ISubject killerSubject
        ) : base(controller)
    {
        this.killerSubject = killerSubject;
    }

    public override void Enter()
    {
        base.Enter();

        killerSubject.Add(this);
    }

    public override void Update()
    {
        return;
    }

    public override void FixedUpdate()
    {
        return;
    }

    public override void Exit()
    {
        base.Exit();

        killerSubject.Remove(this);
    }

    public void OnNotify()
    {
        controller.SwitchState<DeadEnemyState>();
    }
}