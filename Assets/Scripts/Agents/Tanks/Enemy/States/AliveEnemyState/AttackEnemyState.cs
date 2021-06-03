using UnityEngine;

public class AttackEnemyState : AliveEnemyStateBase
{
    private readonly AttackEnemyStateData attackEnemyStateData;
    private readonly ICalculateTrajectoryShoot shooter;
    private readonly ILookAtTarget looker;
    private readonly Transform agent;
    private readonly Transform target;

    private bool canShoot = true;
    private Coroutine dodgeRoutine;

    public AttackEnemyState(
        IStateController controller,
        AttackEnemyStateData attackEnemyStateData,
        ICalculateTrajectoryShoot shooter,
        ILookAtTarget looker,
        Transform agent,
        Transform target
        ) : base(controller)
    {
        this.attackEnemyStateData = attackEnemyStateData;
        this.shooter = shooter;
        this.looker = looker;
        this.agent = agent;
        this.target = target;
    }

    public override void Enter()
    {
        base.Enter();

        dodgeRoutine = CoroutinesHelperSingleton.Instance.WaitForSeconds(
            Random.Range(attackEnemyStateData.MinTimeToDodge, attackEnemyStateData.MaxTimeToDodge), () => SwitchToDodgeEnemyState());
    }

    public override void Update()
    {
        Vector3 direction = looker.LookAtTarget(target);

        if (Vector3.Angle(direction, agent.forward) < attackEnemyStateData.RotateToShootPrecision && canShoot)
        {
            shooter.CalculateTrajectoryShoot(target);
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

        CoroutinesHelperSingleton.Instance.StopCoroutine(dodgeRoutine);
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