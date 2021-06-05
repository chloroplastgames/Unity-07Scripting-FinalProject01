using UnityEngine;

public class GameManagerSingleton : Singleton<GameManagerSingleton>,
    IObserver<ButtonPvsPArgs>, IObserver<ButtonPvsCPUArgs>,
    IObserver<Player1CharacterSelectionArgs>, IObserver<Player2CharacterSelectionArgs>,
    IObserver<TimerArgs>, IObserver<DieArgs>,
    IObserver<ButtonRestartEventArgs>
{
    public GameObject Agent1Instance => agent1Instance;
    public GameObject Agent2Instance => agent2Instance;
    public Color Agent1Color => agent1Color;
    public Color Agent2Color => agent2Color;
    public Subject<EndRoundArgs> RoundEnder => roundEnder;
    public GameObject GameWinner => gameWinner;
    public Player1RoundWinnerBehaviour Player1RoundWinner => player1RoundWinner;
    public Player2RoundWinnerBehaviour Player2RoundWinner => player2RoundWinner;
    public int Agent1Wins => agent1Wins;
    public int Agent2Wins => agent2Wins;

    [SerializeField] private GameplayCameraController gameplayCameraController;
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;
    [SerializeField] private int roundsToWin = 4;

    private EndRoundBehaviour roundEnder;

    private GameObject agent1;
    private GameObject agent2;
    private Color agent1Color = Color.black;
    private Color agent2Color = Color.black;

    private GameObject agent1Instance;
    private GameObject agent2Instance;

    private int agent1Wins;
    private int agent2Wins;
    private GameObject gameWinner;

    private bool gameIsSet;

    private Player1RoundWinnerBehaviour player1RoundWinner;
    private Player2RoundWinnerBehaviour player2RoundWinner;

    private IMainMenuEvents mainMenuEvents;
    private ICharacterSelectionPvsPEvents characterSelectionPvsPEvents;
    private ICharacterSelectionPvsCPUEvents characterSelectionPvsCPUEvents;
    private IHUDEvents hudEvents;
    private IHUDSetup hudSetup;
    private IGameOverEvents gameOverEvents;

    protected override void Awake()
    {
        base.Awake();

        roundEnder = GetComponent<EndRoundBehaviour>();

        player1RoundWinner = GetComponent<Player1RoundWinnerBehaviour>();
        player2RoundWinner = GetComponent<Player2RoundWinnerBehaviour>();

        mainMenuEvents = FindObjectOfType<MainMenuController>();
        characterSelectionPvsPEvents = FindObjectOfType<CharacterSelectionPvsPController>();
        characterSelectionPvsCPUEvents = FindObjectOfType<CharacterSelectionPvsCPUController>();
        hudEvents = FindObjectOfType<HUDController>();
        hudSetup = FindObjectOfType<HUDController>();
        gameOverEvents = FindObjectOfType<GameOverController>();
    }

    private void Start()
    {
        mainMenuEvents.ButtonPvsPSubject.Add(this);
        mainMenuEvents.ButtonPvsCPUSubject.Add(this);

        characterSelectionPvsPEvents.Player1CharacterSelectorSubject.Add(this);
        characterSelectionPvsPEvents.Player2CharacterSelectorSubject.Add(this);

        characterSelectionPvsCPUEvents.Player1CharacterSelectorSubject.Add(this);

        hudEvents.TimerSubject.Add(this);

        gameOverEvents.ButtonRestartSubject.Add(this);
    }

    private void OnDisable()
    {
        mainMenuEvents.ButtonPvsPSubject.Remove(this);
        mainMenuEvents.ButtonPvsCPUSubject.Remove(this);

        characterSelectionPvsPEvents.Player1CharacterSelectorSubject.Remove(this);
        characterSelectionPvsPEvents.Player2CharacterSelectorSubject.Remove(this);

        characterSelectionPvsCPUEvents.Player1CharacterSelectorSubject.Add(this);

        hudEvents.TimerSubject.Remove(this);

        gameOverEvents.ButtonRestartSubject.Remove(this);

        agent1Instance.GetComponent<ISubject<DieArgs>>().Remove(this);
        agent2Instance.GetComponent<ISubject<DieArgs>>().Remove(this);
    }

    public void OnNotify(ButtonPvsPArgs buttonPvsPArgs)
    {
        SetAgents(buttonPvsPArgs.agent1, buttonPvsPArgs.agent2);
    }

    public void OnNotify(ButtonPvsCPUArgs buttonPvsCPUArgs)
    {
        SetAgents(buttonPvsCPUArgs.agent1, buttonPvsCPUArgs.agent2);
    }

    public void OnNotify(Player1CharacterSelectionArgs player1ColorArgs)
    {
        SetAgent1Color(player1ColorArgs.player1Color);
    }

    public void OnNotify(Player2CharacterSelectionArgs player2ColorArgs)
    {
        SetAgent2Color(player2ColorArgs.player2Color);
    }

    public void OnNotify(TimerArgs parameter)
    {
        EndRound();
    }

    public void OnNotify(DieArgs parameter)
    {
        EndRound();
    }

    public void OnNotify(ButtonRestartEventArgs parameter)
    {
        ResetScore();
    }

    private void SetAgents(GameObject agent1, GameObject agent2)
    {
        this.agent1 = agent1;
        this.agent2 = agent2;
    }

    private void SetAgent1Color(Color color)
    {
        agent1Color = color;
    }

    private void SetAgent2Color(Color color)
    {
        agent2Color = color;
    }

    public void SetupGame()
    {
        if (gameIsSet) return;

        agent1Instance = Instantiate(agent1, spawnPoint1.position, spawnPoint1.rotation);
        UtilityFunctionsHelper.ColorGameObject(agent1Instance, agent1Color);

        agent1Instance.GetComponent<ISubject<DieArgs>>().Add(this);

        ISubject<HealthChangedArgs> agent1healthSubject = agent1Instance.GetComponent<ISubject<HealthChangedArgs>>();
        hudSetup.SetupLeftHealthHUD(agent1healthSubject);


        agent2Instance = Instantiate(agent2, spawnPoint2.position, spawnPoint2.rotation);
        UtilityFunctionsHelper.ColorGameObject(agent2Instance, agent2Color);

        agent1Instance.GetComponent<ISubject<DieArgs>>().Add(this);

        ISubject<HealthChangedArgs> agent2healthSubject = agent2Instance.GetComponent<ISubject<HealthChangedArgs>>();
        hudSetup.SetupRightHealthHUD(agent2healthSubject);

        gameplayCameraController.Targets = new Transform[] { agent1Instance.transform, agent2Instance.transform };

        gameIsSet = true;
    }

    public void SetupRound()
    {
        // Reset position and rotation
        agent1Instance.transform.position = spawnPoint1.transform.position;
        agent2Instance.transform.position = spawnPoint2.transform.position;

        agent1Instance.transform.rotation = spawnPoint1.transform.rotation;
        agent2Instance.transform.rotation = spawnPoint2.transform.rotation;

        // Reset health
        agent1Instance.GetComponent<IResetHealth>().ResetHealth();
        agent2Instance.GetComponent<IResetHealth>().ResetHealth();

        // Reset camera
        gameplayCameraController.ResetCamera();
    }

    private void EndRound()
    {
        // After tank die
        // Set dead states
        roundEnder.EndRound();

        // Get tanks health
        int tank1Health = agent1Instance.GetComponent<ICurrentHealth>().CurrentHealth;
        int tank2Health = agent2Instance.GetComponent<ICurrentHealth>().CurrentHealth;

        // Get round winner
        if (player1RoundWinner.HasPlayer1WonRound(tank1Health, tank2Health))
        {
            agent1Wins++; // TODO: Redundancy with points in round winner behaviour
        }
        else if (player2RoundWinner.HasPlayer2WonRound(tank1Health, tank2Health))
        {
            agent2Wins++;
        }

        // Get game winner
        if (agent1Wins == roundsToWin)
        {
            gameWinner = agent1Instance;
        }
        else if (agent2Wins == roundsToWin)
        {
            gameWinner = agent2Instance;
        }
    }

    private void ResetScore()
    {
        agent1Wins = 0;
        agent2Wins = 0;
        gameWinner = null;

        player1RoundWinner.ResetPoints();
        player2RoundWinner.ResetPoints();
    }
}