using UnityEngine;

public class EnemyStateController : StateController
{
    private IState spawnEnemyState;
    private IState chaseEnemyState;
    private IState deadEnemyState;

    private ISetDestination destinationSetter;
    private Transform player;
    ISubject dieBehaviour;

    private void Awake()
    {
        destinationSetter = GetComponent<ISetDestination>();
        player = FindObjectOfType<PlayerStateController>().transform; // TODO
        dieBehaviour = GetComponent<DieBehaviour>(); // TODO

        spawnEnemyState = new SpawnEnemyState(
            this
            );
        chaseEnemyState = new ChaseEnemyState(
            this,
            destinationSetter,
            player,
            dieBehaviour
            );
        deadEnemyState = new DeadEnemyState(
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