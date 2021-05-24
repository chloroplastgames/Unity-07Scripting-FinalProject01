using UnityEngine;
using UnityEngine.AI;

public class EnemyStateController : StateController
{
    [SerializeField] private EnemyStateData enemyStateData;
    [SerializeField] private ChaseEnemyStateData chaseEnemyStateData;
    [SerializeField] private AttackEnemyStateData attackEnemyStateData;

    private void Awake()
    {
        Transform player = FindObjectOfType<PlayerStateController>().transform; // TODO
        NavMeshAgent navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        IFire shooter = GetComponent<IFire>();
        ISubject dieBehaviour = GetComponent<DieBehaviour>(); // TODO

        IState spawnEnemyState = new SpawnEnemyState(
            this,
            dieBehaviour
            );
        IState chaseEnemyState = new ChaseEnemyState(
            this,
            chaseEnemyStateData,
            enemyStateData,
            gameObject.transform,
            navMeshAgent,
            player,
            dieBehaviour
            );
        IState attackEnemyState = new AttackEnemyState(
            this,
            attackEnemyStateData,
            shooter,
            gameObject.transform,
            player,
            dieBehaviour
            );
        IState deadEnemyState = new DeadEnemyState(
            this,
            gameObject
            );
        states.Add(typeof(SpawnEnemyState), spawnEnemyState);
        states.Add(typeof(ChaseEnemyState), chaseEnemyState);
        states.Add(typeof(AttackEnemyState), attackEnemyState);
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