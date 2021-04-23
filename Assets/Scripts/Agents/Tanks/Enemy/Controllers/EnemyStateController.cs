public class EnemyStateController : StateController
{
    private IState spawnEnemyState;

    private void Awake()
    {
        spawnEnemyState = new SpawnEnemyState(
            this
            );

        states.Add(typeof(SpawnEnemyState), spawnEnemyState);
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