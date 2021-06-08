﻿using UnityEngine;

public class ChaseEnemyState : AliveEnemyStateBase
{
    private readonly EnemyStateData enemyStateData;
    private readonly INavMeshAgent navMeshAgent;
    private readonly Transform agent;
    private readonly Transform target;

    public ChaseEnemyState(
        IStateController controller,
        EnemyStateData enemyStateData,
        INavMeshAgent navMeshAgent,
        Transform agent,
        Transform target,
        GameController gameController
        ) : base(controller, gameController)
    {
        this.enemyStateData = enemyStateData;
        this.navMeshAgent = navMeshAgent;
        this.agent = agent;
        this.target = target;
    }

    public override void Enter()
    {
        base.Enter();

        navMeshAgent.Resume();

        SetDestination();
    }

    public override void Update()
    {
        // Has seen target
        if (Vector3.SqrMagnitude(target.position - agent.position) <= enemyStateData.VisionRange * enemyStateData.VisionRange)
        {
            SwitchToAttackEnemyState();
            return;
        }

        // Has arrived to destination
        if (navMeshAgent.RemainingDistance <= enemyStateData.RemainingDistance)
        {
            // New destination
            SetDestination();
        }
    }

    public override void FixedUpdate()
    {
        return;
    }

    public override void Exit()
    {
        base.Exit();

        navMeshAgent.Stop();
    }

    private void SetDestination()
    {
        // Return true if it can set destination and also sets destination
        if (navMeshAgent.CanSetDestinationInsideCircle(enemyStateData.MinDistance, enemyStateData.MaxDistance))
        {
            return;
        }
        else
        {
            // New destination
            SetDestination();
        }
    }

    private void SwitchToAttackEnemyState()
    {
        controller.SwitchState<AttackEnemyState>();
    }
}