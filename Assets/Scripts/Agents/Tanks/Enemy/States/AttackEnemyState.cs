using UnityEngine;

public class AttackEnemyState : State, IObserver
{
    private readonly AttackEnemyStateData attackEnemyStateData;
    private readonly IFire shooter;
    private readonly Transform agent;
    private readonly Transform player;
    private readonly ISubject killerSubject;

    private Coroutine attackRoutine;

    public AttackEnemyState(
        IStateController controller,
        AttackEnemyStateData attackEnemyStateData,
        IFire shooter,
        Transform agent,
        Transform player,
        ISubject killerSubject
        ) : base(controller)
    {
        this.attackEnemyStateData = attackEnemyStateData;
        this.shooter = shooter;
        this.agent = agent;
        this.player = player;
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
        LookToTarget();
    }

    public override void FixedUpdate()
    {
        return;
    }

    public override void Exit()
    {
        base.Exit();

        killerSubject.Remove(this);

        RoutineHelperSingleton.Instance.StopCoroutine(attackRoutine);
    }

    public void OnNotify()
    {
        controller.SwitchState<DeadEnemyState>();
    }

    private void LookToTarget()
    {
        Vector3 directionToLook = player.position - agent.position;
        Quaternion targetRotation = Quaternion.LookRotation(directionToLook);
        agent.rotation = Quaternion.Slerp(agent.rotation, targetRotation, attackEnemyStateData.RotationSpeed * Time.deltaTime);
    }

    private void PrepareToShoot()
    {
        attackRoutine = RoutineHelperSingleton.Instance.WaitForSeconds(attackEnemyStateData.TimeBetweenAttacks, () => Shoot());
    }

    private void Shoot()
    {
        shooter.Fire();

        PrepareToShoot();
    }
}