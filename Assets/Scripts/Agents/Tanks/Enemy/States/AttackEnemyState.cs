using UnityEngine;

public class AttackEnemyState : State, IObserver
{
    private readonly AttackEnemyStateData attackEnemyStateData;
    private readonly IFire shooter;
    private readonly ISubject killerSubject;

    private Coroutine attackRoutine; // TODO: in order to stop it if necessary

    public AttackEnemyState(
        IStateController controller,
        AttackEnemyStateData attackEnemyStateData,
        IFire shooter,
        ISubject killerSubject
        ) : base(controller)
    {
        this.attackEnemyStateData = attackEnemyStateData;
        this.shooter = shooter;
        this.killerSubject = killerSubject;
    }

    public override void Enter()
    {
        base.Enter();

        killerSubject.Add(this);

        PrepareToShoot();
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

    private void PrepareToShoot()
    {
        attackRoutine = WaitForSecondsSingleton.Instance.WaitForSeconds(attackEnemyStateData.TimeBetweenAttacks, () => Shoot());
    }

    private void Shoot()
    {
        shooter.Fire();

        PrepareToShoot();
    }
}