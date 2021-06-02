using UnityEngine;

public class AttackEnemyState : State, IObserver<DieArgs>
{
    private readonly AttackEnemyStateData attackEnemyStateData;
    private readonly ICalculateTrajectoryShoot shooter;
    private readonly ILookAtTarget looker;
    private readonly Transform agent;
    private readonly Transform player;
    private readonly ISubject<DieArgs> killerSubject;

    private bool canShoot = true;
    private Coroutine dodgeRoutine;

    public AttackEnemyState(
        IStateController controller,
        AttackEnemyStateData attackEnemyStateData,
        ICalculateTrajectoryShoot shooter,
        ILookAtTarget looker,
        Transform agent,
        Transform player,
        ISubject<DieArgs> killerSubject
        ) : base(controller)
    {
        this.attackEnemyStateData = attackEnemyStateData;
        this.shooter = shooter;
        this.looker = looker;
        this.agent = agent;
        this.player = player;
        this.killerSubject = killerSubject;
    }

    public override void Enter()
    {
        base.Enter();

        killerSubject.Add(this);

        dodgeRoutine = CoroutinesHelperSingleton.Instance.WaitForSeconds(
            Random.Range(attackEnemyStateData.MinTimeToDodge, attackEnemyStateData.MaxTimeToDodge), () => SwitchToDodgeEnemyState());
    }

    public override void Update()
    {
        Vector3 direction = looker.LookAtTarget(player);

        if (Vector3.Angle(direction, agent.forward) < attackEnemyStateData.RotateToShootPrecision && canShoot)
        {
            shooter.CalculateTrajectoryShoot(player);
            canShoot = false;
            CanShootRoutine();
        }
    }

    public override void FixedUpdate()
    {
        return;
    }

    public override void Exit()
    {
        base.Exit();

        killerSubject.Remove(this);

        CoroutinesHelperSingleton.Instance.StopCoroutine(dodgeRoutine);
    }

    public void OnNotify(DieArgs param)
    {
        controller.SwitchState<DeadEnemyState>();
    }

    private void CanShootRoutine()
    {
        CoroutinesHelperSingleton.Instance.WaitForSeconds(attackEnemyStateData.TimeBetweenAttacks, () => CanShoot());
    }

    private void CanShoot()
    {
        canShoot = true;
    }

    private void SwitchToDodgeEnemyState()
    {
        controller.SwitchState<DodgeEnemyState>();
    }
}