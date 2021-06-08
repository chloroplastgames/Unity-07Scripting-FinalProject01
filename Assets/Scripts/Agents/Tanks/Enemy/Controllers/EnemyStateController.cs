using UnityEngine;

/// <summary>
/// Controller to control CPU agent state
/// </summary>

public class EnemyStateController : StateController
{
    // Config
    [SerializeField] private EnemyStateData enemyStateData;
    [SerializeField] private AttackEnemyStateData attackEnemyStateData;

    private void Awake()
    {
        // Player gets instantiated first
        Transform player = FindObjectOfType<PlayerStateController>().transform;

        Transform myAgent = gameObject.transform;
        INavMeshAgent navMeshAgent = GetComponent<INavMeshAgent>();
        ICalculateTrajectoryShoot shooter = GetComponent<ICalculateTrajectoryShoot>();
        ILookAtTarget looker = GetComponent<ILookAtTarget>();

        // TODO: interface
        GameController gameController = FindObjectOfType<GameController>();

        IState spawnEnemyState = new SpawnEnemyState(
            this,
            gameController
            );
        IState chaseEnemyState = new ChaseEnemyState(
            this,
            enemyStateData,
            navMeshAgent,
            myAgent,
            player,
            gameController
            );
        IState attackEnemyState = new AttackEnemyState(
            this,
            attackEnemyStateData,
            shooter,
            looker,
            myAgent,
            player,
            gameController
            );
        IState dodgeEnemyState = new DodgeEnemyState(
            this,
            enemyStateData,
            navMeshAgent,
            gameController
            );
        IState deadEnemyState = new DeadEnemyState(
            this,
            gameController
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