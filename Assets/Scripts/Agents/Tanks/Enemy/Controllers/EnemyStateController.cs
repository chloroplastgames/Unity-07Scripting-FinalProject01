using UnityEngine;

public class EnemyStateController : StateController
{
    [SerializeField] private EnemyStateData enemyStateData;
    [SerializeField] private AttackEnemyStateData attackEnemyStateData;

    private void Awake()
    {
        Transform player = FindObjectOfType<PlayerStateController>().transform;
        Transform myAgent = gameObject.transform;
        INavMeshAgent navMeshAgent = GetComponent<INavMeshAgent>();
        ICalculateTrajectoryShoot shooter = GetComponent<ICalculateTrajectoryShoot>();
        ILookAtTarget looker = GetComponent<ILookAtTarget>();

        ICountdownEvents countdownEvents = FindObjectOfType<CountdownController>();

        IState spawnEnemyState = new SpawnEnemyState(
            this
            );
        IState chaseEnemyState = new ChaseEnemyState(
            this,
            enemyStateData,
            navMeshAgent,
            myAgent,
            player
            );
        IState attackEnemyState = new AttackEnemyState(
            this,
            attackEnemyStateData,
            shooter,
            looker,
            myAgent,
            player
            );
        IState dodgeEnemyState = new DodgeEnemyState(
            this,
            enemyStateData,
            navMeshAgent
            );
        IState deadEnemyState = new DeadEnemyState(
            this,
            countdownEvents
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