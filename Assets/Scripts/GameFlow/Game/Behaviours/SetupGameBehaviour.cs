using UnityEngine;

public class SetupGameBehaviour : Subject<SetupGameEventArgs>
{
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;

    private GameObject agent1;
    private GameObject agent2;
    private Color agent1Color;
    private Color agent2Color;
    private GameObject agent1Instance;
    private GameObject agent2Instance;

    public void SetAgents(GameObject agent1, GameObject agent2)
    {
        this.agent1 = agent1;
        this.agent2 = agent2;
    }

    public void SetAgent1Color(Color agent1Color)
    {
        this.agent1Color = agent1Color;

        if (agent2Color != default)
        {
            SetupGame();
        }
    }

    public void SetAgent2Color(Color agent2Color)
    {
        this.agent2Color = agent2Color;

        if (agent1Color != default)
        {
            SetupGame();
        }
    }

    public override void Notify()
    {
        IObserver<SetupGameEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<SetupGameEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new SetupGameEventArgs(agent1Instance, agent2Instance));
        }
    }

    private void SetupGame()
    {
        agent1Instance = Instantiate(agent1, spawnPoint1.position, spawnPoint1.rotation);
        UtilityFunctionsHelper.ColorGameObject(agent1Instance, agent1Color);

        agent2Instance = Instantiate(agent2, spawnPoint2.position, spawnPoint2.rotation);
        UtilityFunctionsHelper.ColorGameObject(agent2Instance, agent2Color);

        Notify();
    }
}