using UnityEngine;
using UnityEngine.AI;

public class EnemyStateController : StateController
{
    [SerializeField] private ChaseEnemyStateData chaseEnemyStateData;

    private void Awake()
    {
        Transform player = FindObjectOfType<PlayerStateController>().transform; // TODO
        NavMeshAgent navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        ISubject dieBehaviour = GetComponent<DieBehaviour>(); // TODO

        IState spawnEnemyState = new SpawnEnemyState(
            this
            );
        IState chaseEnemyState = new ChaseEnemyState(
            this,
            gameObject.transform,
            navMeshAgent,
            player,
            dieBehaviour,
            chaseEnemyStateData
            );
        IState attackEnemyState = new AttackEnemyState(
            this,
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