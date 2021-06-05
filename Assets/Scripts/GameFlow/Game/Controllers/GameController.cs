using UnityEngine;

public class GameController : MonoBehaviour, IObserver<SetupGameEventArgs>, IObserver<CountdownEventArgs>,
    IObserver<TimerEventArgs>, IObserver<DieEventArgs>
{
    public ISubject<SetupGameEventArgs> SetupGameSubject => setupGameSubject;
    public ISubject<StartRoundEventArgs> StartRoundSubject => startRoundSubject;
    public ISubject<EndRoundEventArgs> EndRoundSubject => endRoundSubject;

    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;

    private SetupGameBehaviour gameSetup;
    private StartRoundBehaviour roundStart;
    private EndRoundBehaviour roundEnd;

    private ISubject<SetupGameEventArgs> setupGameSubject;
    private ISubject<StartRoundEventArgs> startRoundSubject;
    private ISubject<EndRoundEventArgs> endRoundSubject;

    private GameObject agent1;
    private GameObject agent2;
    private Color agent1Color;
    private Color agent2Color;

    private ICountdownEvents countdownEvents;
    private IHUDEvents hudEvents;

    private ISubject<DieEventArgs> agent1DieSubject;
    private ISubject<DieEventArgs> agent2DieSubject;

    private void Awake()
    {
        gameSetup = GetComponent<SetupGameBehaviour>();
        roundStart = GetComponent<StartRoundBehaviour>();
        roundEnd = GetComponent<EndRoundBehaviour>();

        setupGameSubject = GetComponent<SetupGameBehaviour>();
        startRoundSubject = GetComponent<StartRoundBehaviour>();
        endRoundSubject = GetComponent<EndRoundBehaviour>();

        countdownEvents = FindObjectOfType<CountdownController>();
        hudEvents = FindObjectOfType<HUDController>();
    }

    private void Start()
    {
        setupGameSubject.Add(this);
        countdownEvents.CounterSubject.Add(this);
        hudEvents.TimerSubject.Add(this);
    }

    private void OnDestroy()
    {
        setupGameSubject.Remove(this);
        countdownEvents.CounterSubject?.Remove(this);
        hudEvents.TimerSubject?.Remove(this);

        agent1DieSubject?.Remove(this);
        agent2DieSubject?.Remove(this);
    }

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

    public void OnNotify(SetupGameEventArgs setupGameEventArgs)
    {
        agent1DieSubject = setupGameEventArgs.agent1Instance.GetComponent<ISubject<DieEventArgs>>();
        agent1DieSubject.Add(this);

        agent2DieSubject = setupGameEventArgs.agent2Instance.GetComponent<ISubject<DieEventArgs>>();
        agent2DieSubject.Add(this);
    }

    public void OnNotify(CountdownEventArgs parameter)
    {
        StartRound();
    }

    public void OnNotify(TimerEventArgs parameter)
    {
        EndRound();
    }

    public void OnNotify(DieEventArgs parameter)
    {
        EndRound();
    }

    private void SetupGame()
    {
        gameSetup.SetupGame(agent1, spawnPoint1, agent1Color, agent2, spawnPoint2, agent2Color);
    }

    private void StartRound()
    {
        roundStart.StartRound();
    }

    private void EndRound()
    {
        roundEnd.EndRound();
    }
}