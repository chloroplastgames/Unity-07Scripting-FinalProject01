using UnityEngine;

public class GameController : MonoBehaviour,
    IObserver<SetupGameEventArgs>, IObserver<CountdownEventArgs>,
    IObserver<TimerEventArgs>, IObserver<DieEventArgs>,
    IObserver<ButtonRestartEventArgs>
{
    public ISubject<SetupGameEventArgs> SetupGameSubject => setupGameSubject;
    public ISubject<StartRoundEventArgs> StartRoundSubject => startRoundSubject;
    public ISubject<EndRoundEventArgs> EndRoundSubject => endRoundSubject;

    public ISubject<PointsEventArgs> Agent1PointsSubject => agent1PointsSubject;
    public ISubject<PointsEventArgs> Agent2PointsSubject => agent2PointsSubject;
    public ISubject<GameWinnerEventArgs> GameWinnerSubject => gameWinnerSubject;

    public Transform SpawnPoint1 => spawnPoint1;
    public Transform SpawnPoint2 => spawnPoint2;

    public Color Agent1Color => agent1Color;
    public Color Agent2Color => agent2Color;

    [SerializeField] private int roundsToWin = 4;
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;

    private GameObject agent1;
    private GameObject agent2;
    private Color agent1Color;
    private Color agent2Color;

    private SetupGameBehaviour gameSetup;
    private StartRoundBehaviour roundStart;
    private EndRoundBehaviour roundEnd;

    private ISubject<SetupGameEventArgs> setupGameSubject;
    private ISubject<StartRoundEventArgs> startRoundSubject;
    private ISubject<EndRoundEventArgs> endRoundSubject;

    private Agent1RoundWinnerBehaviour agent1RoundWinner;
    private Agent2RoundWinnerBehaviour agent2RoundWinner;
    private GameWinnerBehaviour gameWinner;

    private ISubject<PointsEventArgs> agent1PointsSubject;
    private ISubject<PointsEventArgs> agent2PointsSubject;
    private ISubject<GameWinnerEventArgs> gameWinnerSubject;

    private ICountdownEvents countdownEvents;
    private IHUDEvents hudEvents;
    private IGameOverEvents gameOverEvents;

    private GameObject agent1Instance;
    private GameObject agent2Instance;

    private ISubject<DieEventArgs> agent1DieSubject;
    private ISubject<DieEventArgs> agent2DieSubject;

    private ICurrentHealth agent1HealthGetter;
    private ICurrentHealth agent2HealthGetter;

    private void Awake()
    {
        gameSetup = GetComponent<SetupGameBehaviour>();
        roundStart = GetComponent<StartRoundBehaviour>();
        roundEnd = GetComponent<EndRoundBehaviour>();

        setupGameSubject = GetComponent<SetupGameBehaviour>();
        startRoundSubject = GetComponent<StartRoundBehaviour>();
        endRoundSubject = GetComponent<EndRoundBehaviour>();

        agent1RoundWinner = GetComponent<Agent1RoundWinnerBehaviour>();
        agent2RoundWinner = GetComponent<Agent2RoundWinnerBehaviour>();
        gameWinner = GetComponent<GameWinnerBehaviour>();

        agent1PointsSubject = GetComponent<Agent1RoundWinnerBehaviour>();
        agent2PointsSubject = GetComponent<Agent2RoundWinnerBehaviour>();
        gameWinnerSubject = GetComponent<GameWinnerBehaviour>();

        countdownEvents = FindObjectOfType<CountdownController>();
        hudEvents = FindObjectOfType<HUDController>();
        gameOverEvents = FindObjectOfType<GameOverController>();
    }

    private void Start()
    {
        setupGameSubject.Add(this);
        countdownEvents.CounterSubject.Add(this);
        hudEvents.TimerSubject.Add(this);
        gameOverEvents.ButtonRestartSubject.Add(this);
    }

    private void OnDestroy()
    {
        setupGameSubject.Remove(this);
        countdownEvents.CounterSubject?.Remove(this);
        hudEvents.TimerSubject?.Remove(this);
        gameOverEvents.ButtonRestartSubject?.Remove(this);

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
        Setup(setupGameEventArgs.agent1Instance, setupGameEventArgs.agent2Instance);
    }

    public void OnNotify(CountdownEventArgs parameter)
    {
        StartRound();
    }

    public void OnNotify(DieEventArgs dieEventArgs)
    {
        EndRound();

        GetRoundWinner(dieEventArgs.agentInstance);
    }

    public void OnNotify(TimerEventArgs parameter)
    {
        EndRound();

        GetRoundWinner();
    }

    public void OnNotify(ButtonRestartEventArgs parameter)
    {
        ResetScore();
    }

    private void Setup(GameObject agent1Instance, GameObject agent2Instance)
    {
        this.agent1Instance = agent1Instance;
        this.agent2Instance = agent2Instance;

        agent1DieSubject = agent1Instance.GetComponent<ISubject<DieEventArgs>>();
        agent1DieSubject.Add(this);

        agent2DieSubject = agent2Instance.GetComponent<ISubject<DieEventArgs>>();
        agent2DieSubject.Add(this);

        agent1HealthGetter = agent1Instance.GetComponent<ICurrentHealth>();
        agent2HealthGetter = agent2Instance.GetComponent<ICurrentHealth>();
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

    private void GetRoundWinner(GameObject loser)
    {
        if (loser == agent2Instance)
        {
            CheckAgent1Win();
        }
        else if (loser == agent1Instance)
        {
            CheckAgent2Win();
        }
    }

    private void GetRoundWinner()
    {
        if (agent1HealthGetter.CurrentHealth > agent2HealthGetter.CurrentHealth)
        {
            CheckAgent1Win();
        }
        else if (agent2HealthGetter.CurrentHealth > agent1HealthGetter.CurrentHealth)
        {
            CheckAgent2Win();
        }
        else
        {
            IsGameWinner(0, new GameWinner());
        }
    }

    private void CheckAgent1Win()
    {
        int agent1Points = agent1RoundWinner.IncrementPoints();

        IsGameWinner(agent1Points, new GameWinner(agent1Instance, "Player 1", agent1Color));
    }

    private void CheckAgent2Win()
    {
        int agent2Points = agent2RoundWinner.IncrementPoints();

        IsGameWinner(agent2Points, new GameWinner(agent2Instance, "Player 2", agent2Color));
    }

    private void IsGameWinner(int points, GameWinner winner)
    {
        if (points == roundsToWin)
        {
            gameWinner.GameWinner = winner;
        }
        else
        {
            gameWinner.GameWinner = new GameWinner();
        }
    }

    private void ResetScore()
    {
        agent1RoundWinner.ResetPoints();
        agent2RoundWinner.ResetPoints();
    }
}