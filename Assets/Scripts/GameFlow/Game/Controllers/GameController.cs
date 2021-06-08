using UnityEngine;

/// <summary>
/// Game Controller
/// </summary>

// TODO: refactor

public class GameController : MonoBehaviour,
    IObserver<SetupGameEventArgs>, IObserver<CountdownEventArgs>,
    IObserver<TimerEventArgs>, IObserver<DieEventArgs>,
    IObserver<ButtonRestartEventArgs>,
    IObserver<CancelEventArgs>
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
    private bool color1Set;
    private bool color2Set;

    private SetupGameBehaviour gameSetup;
    private StartRoundBehaviour roundStart;
    private EndRoundBehaviour roundEnd;

    private ISubject<SetupGameEventArgs> setupGameSubject;
    private ISubject<StartRoundEventArgs> startRoundSubject;
    private ISubject<EndRoundEventArgs> endRoundSubject;

    private Agent1PointsBehaviour agent1RoundWinner;
    private Agent2PointsBehaviour agent2RoundWinner;
    private GameWinnerBehaviour gameWinner;

    private ISubject<PointsEventArgs> agent1PointsSubject;
    private ISubject<PointsEventArgs> agent2PointsSubject;
    private ISubject<GameWinnerEventArgs> gameWinnerSubject;

    private ICountdownEvents countdownEvents;
    private IHUDEvents hudEvents;
    private IGameOverEvents gameOverEvents;
    private ICharacterSelectionPvsPEvents characterSelectionPvsPEvents;

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

        agent1RoundWinner = GetComponent<Agent1PointsBehaviour>();
        agent2RoundWinner = GetComponent<Agent2PointsBehaviour>();
        gameWinner = GetComponent<GameWinnerBehaviour>();

        agent1PointsSubject = GetComponent<Agent1PointsBehaviour>();
        agent2PointsSubject = GetComponent<Agent2PointsBehaviour>();
        gameWinnerSubject = GetComponent<GameWinnerBehaviour>();

        countdownEvents = FindObjectOfType<CountdownController>();
        hudEvents = FindObjectOfType<HUDController>();
        gameOverEvents = FindObjectOfType<GameOverController>();
        characterSelectionPvsPEvents = FindObjectOfType<CharacterSelectionPvsPController>();
    }

    private void Start()
    {
        setupGameSubject.Add(this);
        countdownEvents.CounterSubject.Add(this);
        hudEvents.TimerSubject.Add(this);
        gameOverEvents.ButtonRestartSubject.Add(this);
        characterSelectionPvsPEvents.CancelCharacterSelectionSubject.Add(this);
    }

    private void OnDestroy()
    {
        setupGameSubject.Remove(this);
        countdownEvents.CounterSubject?.Remove(this);
        hudEvents.TimerSubject?.Remove(this);
        gameOverEvents.ButtonRestartSubject?.Remove(this);
        characterSelectionPvsPEvents.CancelCharacterSelectionSubject?.Remove(this);

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
        color1Set = true;

        if (color2Set)
        {
            SetupGame();
        }
    }

    public void SetAgent2Color(Color agent2Color)
    {
        this.agent2Color = agent2Color;
        color2Set = true;

        if (color1Set)
        {
            SetupGame();
        }
    }

    // Get instances of the agents
    public void OnNotify(SetupGameEventArgs setupGameEventArgs)
    {
        Setup(setupGameEventArgs.agent1Instance, setupGameEventArgs.agent2Instance);
    }

    // When countdown finishes, start round
    public void OnNotify(CountdownEventArgs parameter)
    {
        StartRound();
    }

    // When agent die or time finishes, end round
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

    // When restart game, reset score
    public void OnNotify(ButtonRestartEventArgs parameter)
    {
        ResetScore();
    }

    public void OnNotify(CancelEventArgs parameter)
    {
        CancelCharacterSelection();
    }

    // Suscribe to agent instances events
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

    // Create instances
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

    // Get round winner with die event, passing the dead agent or with timer, checking agents health
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

    // Check points of agent 1
    private void CheckAgent1Win()
    {
        int agent1Points = agent1RoundWinner.IncrementPoints();

        IsGameWinner(agent1Points, new GameWinner(agent1Instance, "Player 1", agent1Color));
    }

    // Check points of agent 2
    private void CheckAgent2Win()
    {
        int agent2Points = agent2RoundWinner.IncrementPoints();

        IsGameWinner(agent2Points, new GameWinner(agent2Instance, "Player 2", agent2Color));
    }

    // Compares points to get a winner
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

    private void CancelCharacterSelection()
    {
        color1Set = false;
        color2Set = false;
    }
}