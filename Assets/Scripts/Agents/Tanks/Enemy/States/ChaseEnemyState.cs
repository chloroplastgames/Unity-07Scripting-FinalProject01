using UnityEngine;

public class ChaseEnemyState : State, IObserver
{
    private readonly ISetDestination destinationSetter;
    private readonly Transform player;
    private readonly ISubject killerSubject;

    public ChaseEnemyState(
        IStateController controller,
        ISetDestination destinationSetter,
        Transform player,
        ISubject killerSubject
        ) : base(controller)
    {
        this.destinationSetter = destinationSetter;
        this.player = player;
        this.killerSubject = killerSubject;
    }

    public override void Enter()
    {
        base.Enter();

        killerSubject.Add(this);
    }

    public override void Update()
    {
        destinationSetter.SetDestination(player.position);
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