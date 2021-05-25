﻿using UnityEngine;

public class EnemyStateController : StateController
{
    [SerializeField] private EnemyStateData enemyStateData;
    [SerializeField] private AttackEnemyStateData attackEnemyStateData;

    private void Awake()
    {
        Transform player = FindObjectOfType<PlayerStateController>().transform; // TODO
        INavMeshAgent navMeshAgent = GetComponent<INavMeshAgent>();
        ICalculateTrajectoryShoot shooter = GetComponent<ICalculateTrajectoryShoot>();
        ILookAtTarget looker = GetComponent<ILookAtTarget>();
        ISubject dieBehaviour = GetComponent<DieBehaviour>(); // TODO

        IState spawnEnemyState = new SpawnEnemyState(
            this,
            dieBehaviour
            );
        IState chaseEnemyState = new ChaseEnemyState(
            this,
            enemyStateData,
            navMeshAgent,
            gameObject.transform,
            player,
            dieBehaviour
            );
        IState attackEnemyState = new AttackEnemyState(
            this,
            attackEnemyStateData,
            shooter,
            looker,
            gameObject.transform,
            player,
            dieBehaviour
            );
        IState dodgeEnemyState = new DodgeEnemyState(
            this,
            enemyStateData,
            navMeshAgent,
            dieBehaviour
            );
        IState deadEnemyState = new DeadEnemyState(
            this,
            gameObject
            );
        states.Add(typeof(SpawnEnemyState), spawnEnemyState);
        states.Add(typeof(ChaseEnemyState), chaseEnemyState);
        states.Add(typeof(AttackEnemyState), attackEnemyState);
        states.Add(typeof(DodgeEnemyState), dodgeEnemyState);
        states.Add(typeof(DeadEnemyState), deadEnemyState);
    }

    private void Start()
    {
        SwitchState<SpawnEnemyState>();
    }

    private void Update()
    {
        currentState.Update();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }
}