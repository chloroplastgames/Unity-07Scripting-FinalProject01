using UnityEngine;

public class GameController : MonoBehaviour, IObserver<SetupGameEventArgs>, IObserver<DieEventArgs>
{
    public ISubject<SetupGameEventArgs> SetupGameSubject => setupGameSubject;
    public ISubject<StartRoundEventArgs> SetupRoundSubject => setupRoundSubject;

    private SetupGameBehaviour gameSetup;
    private StartRoundBehaviour roundSetup;

    private ISubject<SetupGameEventArgs> setupGameSubject;
    private ISubject<StartRoundEventArgs> setupRoundSubject;

    private void Awake()
    {
        gameSetup = GetComponent<SetupGameBehaviour>();
        roundSetup = GetComponent<StartRoundBehaviour>();

        setupGameSubject = GetComponent<SetupGameBehaviour>();
        setupRoundSubject = GetComponent<StartRoundBehaviour>();
    }

    public void SetAgents(GameObject agent1, GameObject agent2)
    {
        gameSetup.SetAgents(agent1, agent2);
    }

    public void SetAgent1Color(Color agent1Color)
    {
        gameSetup.SetAgent1Color(agent1Color);
    }

    public void SetAgent2Color(Color agent2Color)
    {
        gameSetup.SetAgent2Color(agent2Color);
    }

    public void OnNotify(SetupGameEventArgs setupGameArgs)
    {
        roundSetup.SetupRound();

        ISubject<DieEventArgs> agent1DieSubject = setupGameArgs.agent1Instance.GetComponent<ISubject<DieEventArgs>>();
        agent1DieSubject.Add(this);

        ISubject<DieEventArgs> agent2DieSubject = setupGameArgs.agent2Instance.GetComponent<ISubject<DieEventArgs>>();
        agent2DieSubject.Add(this);
    }

    public void OnNotify(DieEventArgs parameter)
    {
        throw new System.NotImplementedException();
    }
}