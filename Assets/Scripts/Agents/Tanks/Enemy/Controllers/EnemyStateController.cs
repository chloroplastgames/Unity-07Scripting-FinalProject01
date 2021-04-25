using UnityEngine;

public class EnemyStateController : StateController
{
    [SerializeField] private ChaseEnemyStateData chaseEnemyStateData;

    private void Awake()
    {
        ISetDestination destinationSetter = GetComponent<ISetDestination>();
        Transform player = FindObjectOfType<PlayerStateController>().transform; // TODO
        Transform myAgent = gameObject.transform;
        ISubject dieBehaviour = GetComponent<DieBehaviour>(); // TODO

        IState spawnEnemyState = new SpawnEnemyState(
            this
            );
        IState chaseEnemyState = new ChaseEnemyState(
            this,
            destinationSetter,
            myAgent,
            player,
            dieBehaviour,
            chaseEnemyStateData
            );
        IState deadEnemyState = new DeadEnemyState(
            this
            );
        states.Add(typeof(SpawnEnemyState), spawnEnemyState);
        states.Add(typeof(ChaseEnemyState), chaseEnemyState);
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