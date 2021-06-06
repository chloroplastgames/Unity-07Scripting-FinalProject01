using UnityEngine;

public class GameplayCameraController : MonoBehaviour,
    IObserver<SetupGameEventArgs>,
    IObserver<StartRoundEventArgs>,
    IObserver<GameWinnerEventArgs>,
    IObserver<ButtonRestartEventArgs>,
    IObserver<HealthChangedEventArgs>
{
    [SerializeField] private CameraShakeBehaviour cameraShaker;

    private Transform[] targets;
    private ICameraMove cameraMover;
    private ICameraZoom cameraZoomer;

    GameController gameController;
    IGameOverEvents gameOverEvents;

    private Vector3 initialPosition;
    private bool isFixed;

    private ISubject<HealthChangedEventArgs> player1HealthChanged;
    private ISubject<HealthChangedEventArgs> player2HealthChanged;

    private void Awake()
    {
        cameraMover = GetComponent<ICameraMove>();
        cameraZoomer = GetComponent<ICameraZoom>();

        gameController = FindObjectOfType<GameController>();
        gameOverEvents = FindObjectOfType<GameOverController>();
    }

    private void Start()
    {
        initialPosition = transform.position;

        gameController.SetupGameSubject.Add(this);
        gameController.StartRoundSubject.Add(this);
        gameController.GameWinnerSubject.Add(this);
        gameOverEvents.ButtonRestartSubject.Add(this);
    }

    private void FixedUpdate()
    {
        if (targets == null) return;

        if (isFixed) return;

        cameraMover.MoveCamera(targets);
        cameraZoomer.ZoomCamera(targets, cameraMover.FindAveragePosition(targets));
    }

    private void OnDestroy()
    {
        gameController.SetupGameSubject?.Remove(this);
        gameController.StartRoundSubject?.Remove(this);
        gameController.GameWinnerSubject?.Remove(this);
        gameOverEvents.ButtonRestartSubject?.Remove(this);

        player1HealthChanged?.Remove(this);
        player2HealthChanged?.Remove(this);
    }

    public void OnNotify(SetupGameEventArgs setupGameArgs)
    {
        SetTargets(new Transform[] { setupGameArgs.agent1Instance.transform, setupGameArgs.agent2Instance.transform });
        Setup(setupGameArgs.agent1Instance, setupGameArgs.agent2Instance);
    }

    public void OnNotify(StartRoundEventArgs parameter)
    {
        ResetCamera();
    }

    public void OnNotify(GameWinnerEventArgs gameWinnerEventArgs)
    {
        if (gameWinnerEventArgs.gameWinner.instance != null)
        {
            SetToInitialPosition();
        }
    }

    public void OnNotify(ButtonRestartEventArgs parameter)
    {
        UnFix();
    }

    public void OnNotify(HealthChangedEventArgs healthChangedEventArgs)
    {
        if (healthChangedEventArgs.currentHealth != healthChangedEventArgs.maxHealth)
        {
            StartCoroutine(cameraShaker.ShakeRoutine());
        }
    }

    private void SetTargets(Transform[] targets)
    {
        this.targets = targets;
    }

    private void Setup(GameObject agent1Instace, GameObject agent2Instance)
    {
        player1HealthChanged = agent1Instace.GetComponent<ISubject<HealthChangedEventArgs>>();
        player1HealthChanged.Add(this);

        player2HealthChanged = agent2Instance.GetComponent<ISubject<HealthChangedEventArgs>>();
        player2HealthChanged.Add(this);
    }

    private void ResetCamera()
    {
        cameraMover.ResetPosition(targets);
        cameraZoomer.ResetZoom(targets, cameraMover.FindAveragePosition(targets));
    }

    private void SetToInitialPosition()
    {
        transform.position = initialPosition;
        isFixed = true;
    }

    private void UnFix()
    {
        isFixed = false;
    }
}