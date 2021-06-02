using UnityEngine;

public class GameManagerSingleton : Singleton<GameManagerSingleton>
{
    public GameObject Tank1Instance => tank1Instance;
    public GameObject Tank2Instance => tank2Instance;

    [SerializeField] private CameraController cameraController;
    [SerializeField] private GameObject player1Tank;
    [SerializeField] private GameObject player2Tank;
    [SerializeField] private GameObject cpuTank;
    [SerializeField] private Transform spawnPoint1;
    [SerializeField] private Transform spawnPoint2;

    private GameObject tank1;
    private GameObject tank2;
    private Color tank1Color;
    private Color tank2Color;
    private GameObject tank1Instance;
    private GameObject tank2Instance;

    public void SetPvsP()
    {
        tank1 = player1Tank;
        tank2 = player2Tank;
    }

    public void SetPvsCPU()
    {
        tank1 = player1Tank;
        tank2 = cpuTank;
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
        // Reset position
        tank1Instance.transform.position = spawnPoint1.transform.position;
        tank2Instance.transform.position = spawnPoint2.transform.position;

        // Reset health

        // Reset camera
        cameraController.ResetCamera();

        // Increment round
    }

    public void StartRound()
    {
        // After countdown
        // Set alive states
    }

    public void EndRound()
    {
        // After tank die
        // Set dead states
        // Get round winner or game winner
    }
}