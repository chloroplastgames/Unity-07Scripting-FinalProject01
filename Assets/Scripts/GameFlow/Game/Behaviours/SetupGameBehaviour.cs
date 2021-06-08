using UnityEngine;

/// <summary>
/// Behaviour to create the instances of the agents and pass them to other scripts
/// </summary>

public class SetupGameBehaviour : Subject<SetupGameEventArgs>
{
    private GameObject agent1Instance;
    private GameObject agent2Instance;

    // Instantiates agents and notifies, passing the instances as parameters with the event
    public void SetupGame(GameObject agent1, Transform spawnPoint1, Color agent1Color,
        GameObject agent2, Transform spawnPoint2, Color agent2Color)
    {
        agent1Instance = Instantiate(agent1, spawnPoint1.position, spawnPoint1.rotation);
        UtilityFunctionsHelper.ColorGameObject(agent1Instance, agent1Color);

        agent2Instance = Instantiate(agent2, spawnPoint2.position, spawnPoint2.rotation);
        UtilityFunctionsHelper.ColorGameObject(agent2Instance, agent2Color);

        Notify();
    }

    public override void Notify()
    {
        IObserver<SetupGameEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<SetupGameEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new SetupGameEventArgs(agent1Instance, agent2Instance));
        }
    }
}