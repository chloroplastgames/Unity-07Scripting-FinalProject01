using UnityEngine;

public class AttackEnemyState : State
{
    private readonly AttackEnemyStateData attackEnemyStateData;
    private readonly ICalculateTrajectoryShoot shooter;
    private readonly ILookAtTarget looker;
    private readonly Transform agent;
    private readonly Transform player;

    private bool canShoot = true;
    private Coroutine dodgeRoutine;

    public AttackEnemyState(
        IStateController controller,
        AttackEnemyStateData attackEnemyStateData,
        ICalculateTrajectoryShoot shooter,
        ILookAtTarget looker,
        Transform agent,
        Transform player
        ) : base(controller)
    {
        this.attackEnemyStateData = attackEnemyStateData;
        this.shooter = shooter;
        this.looker = looker;
        this.agent = agent;
        this.player = player;
    }

    public override void Enter()
    {
        base.Enter();

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

    private void SwitchToDeadEnemyState()
    {
        controller.SwitchState<DeadEnemyState>();
    }
}