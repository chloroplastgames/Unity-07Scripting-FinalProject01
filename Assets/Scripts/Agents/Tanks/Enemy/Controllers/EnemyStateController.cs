using UnityEngine;

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

        IState spawnEnemyState = new SpawnEnemyState(
            this
            );
        IState chaseEnemyState = new ChaseEnemyState(
            this,
            enemyStateData,
            navMeshAgent,
            gameObject.transform,
            player
            );
        IState attackEnemyState = new AttackEnemyState(
            this,
            attackEnemyStateData,
            shooter,
            looker,
            gameObject.transform,
            player
            );
        IState dodgeEnemyState = new DodgeEnemyState(
            this,
            enemyStateData,
            navMeshAgent
            );
        IState deadEnemyState = new DeadEnemyState(
            this
            );
        states.Add(typeof(SpawnEnemyState), spawnEnemyState);
        states.Add(typeof(ChaseEnemyState), chaseEnemyState);
        states.Add(typeof(AttackEnemyState), attackEnemyState);
        states.Add(typeof(DodgeEnemyState), dodgeEnemyState);
        states.Add(typeof(DeadEnemyState), deadEnemyState);
    }

    private void Start()
    {
        SwitchState<DeadEnemyState>();
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