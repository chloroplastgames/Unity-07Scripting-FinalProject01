using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerSingleton : Singleton<GameManagerSingleton>
{
    public GameObject Tank1Instance => tank1Instance;
    public GameObject Tank2Instance => tank2Instance;
    public Subject<StartRoundArgs> RoundStarter => roundStarter;
    public Subject<EndRoundArgs> RoundEnder => roundEnder;
    public GameObject GameWinner => gameWinner;

    // TODO: Config => ScriptableObject
    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject player1Tank;
    [SerializeField] private GameObject player2Tank;
    [SerializeField] private GameObject cpuTank;
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;
    [SerializeField] private int roundsToWin = 4;

    private StartRoundBehaviour roundStarter;
    private EndRoundBehaviour roundEnder;

    private GameObject tank1;
    private GameObject tank2;
    private Color tank1Color;
    private Color tank2Color;

    private GameObject tank1Instance;
    private GameObject tank2Instance;

    private int tank1Wins;
    private int tank2Wins;
    private GameObject gameWinner;

    protected override void Awake()
    {
        base.Awake();

        roundStarter = GetComponent<StartRoundBehaviour>();
        roundEnder = GetComponent<EndRoundBehaviour>();
    }

    public void SetPvsP()
    {
        tank1 = player1Tank;
        tank2 = player2Tank;
    }

    public void SetPvsCPU()
    {
        tank1 = player1Tank;
        tank2 = cpuTank;

        tank2Color = Color.black; // TODO
    }

    public void SetTank1Color(Color color)
    {
        tank1Color = color;
    }

    public void SetTank2Color(Color color)
    {
        tank2Color = color;
    }

    public void SetupGame()
    {
        tank1Instance = Instantiate(tank1, spawnPoint1.position, spawnPoint1.rotation);
        UtilityFunctionsHelper.ColorGameObject(tank1Instance, tank1Color);

        tank2Instance = Instantiate(tank2, spawnPoint2.position, spawnPoint2.rotation);
        UtilityFunctionsHelper.ColorGameObject(tank2Instance, tank2Color);

        cameraController.Targets = new Transform[] { tank1Instance.transform, tank2Instance.transform };
    }

    public void SetupRound()
    {
        // Reset position and rotation
        tank1Instance.transform.position = spawnPoint1.transform.position;
        tank2Instance.transform.position = spawnPoint2.transform.position;

        tank1Instance.transform.rotation = spawnPoint1.transform.rotation;
        tank2Instance.transform.rotation = spawnPoint2.transform.rotation;

        // Reset health
        tank1Instance.GetComponent<IResetHealth>().ResetHealth();
        tank2Instance.GetComponent<IResetHealth>().ResetHealth();

        // Reset camera
        cameraController.ResetCamera();
    }

    public void StartRound()
    {
        // After countdown
        // Set alive states
        roundStarter.StartRound();
    }

    public void EndRound()
    {
        // After tank die
        // Set dead states
        roundEnder.EndRound();

        // Get tanks health
        int tank1Health = tank1Instance.GetComponent<ICurrentHealth>().CurrentHealth;
        int tank2Health = tank2Instance.GetComponent<ICurrentHealth>().CurrentHealth;

        // Get round winner
        if (tank2Health == 0 || tank1Health > tank2Health)
        {
            tank1Wins++;
        }
        else
        {
            tank2Wins++;
        }

        // Get game winner
        if (tank1Wins == roundsToWin)
        {
            gameWinner = tank1Instance;
        }
        else if (tank2Wins == roundsToWin)
        {
            gameWinner = tank2Instance;
        }
    }

    public void ResetGameSoft()
    {
        tank1Wins = 0;
        tank2Wins = 0;
        gameWinner = null;
    }

    public void ResetGameHard()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}