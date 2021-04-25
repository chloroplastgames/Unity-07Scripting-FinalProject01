// CONTINUE

using UnityEngine;

public class ChaseEnemyState : State, IObserver
{
    private readonly ISetDestination destinationSetter;
    private readonly Transform agent;
    private readonly Transform player;
    private readonly ISubject killerSubject;
    private readonly ChaseEnemyStateData chaseEnemyStateData;

    private Vector3 destination;

    public ChaseEnemyState(
        IStateController controller,
        ISetDestination destinationSetter,
        Transform agent,
        Transform player,
        ISubject killerSubject,
        ChaseEnemyStateData chaseEnemyStateData
        ) : base(controller)
    {
        this.destinationSetter = destinationSetter;
        this.agent = agent;
        this.player = player;
        this.killerSubject = killerSubject;
        this.chaseEnemyStateData = chaseEnemyStateData;
    }

    public override void Enter()
    {
        base.Enter();

        killerSubject.Add(this);

        SetDestination();
    }

    public override void Update()
    {
        if (Vector3.Distance(agent.position, player.position) <= chaseEnemyStateData.VisionRange)
        {
            // Switch to Attack State
            Debug.Log("Switch to Attack State");
            return;
        }

        if (Vector3.Distance(agent.position, destination) <= Mathf.Epsilon) // Increment distance check
        {
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

        killerSubject.Remove(this);
    }

    public void OnNotify()
    {
        controller.SwitchState<DeadEnemyState>();
    }

    private void SetDestination()
    {
        Vector2 temp =
            Random.insideUnitCircle * (Random.Range(chaseEnemyStateData.MinChaseDistance, chaseEnemyStateData.MaxChaseDistance));

        destination = new Vector3(temp.x, 0, temp.y);

        Debug.Log(destination);

        // Inifite loop
        //if (!destinationSetter.TrySetDestination(destination))
        //{
        //    SetDestination();
        //}

        destinationSetter.SetDestination(destination);
    }
}