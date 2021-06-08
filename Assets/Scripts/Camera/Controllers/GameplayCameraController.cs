using UnityEngine;

public class GameplayCameraController : MonoBehaviour,
    IObserver<SetupGameEventArgs>,
    IObserver<StartRoundEventArgs>,
    IObserver<GameWinnerEventArgs>,
    IObserver<ButtonRestartEventArgs>,
    IObserver<DecrementHealthEventArgs>
{
    private Transform[] targets;
    private ICameraMove cameraMover;
    private ICameraZoom cameraZoomer;
    private ICameraShake cameraShaker;

    GameController gameController;
    IGameOverEvents gameOverEvents;

    private Vector3 initialPosition;
    private bool isFixed;

    private ISubject<DecrementHealthEventArgs> player1DamageSubject;
    private ISubject<DecrementHealthEventArgs> player2DamageSubject;

    private void Awake()
    {
        cameraMover = GetComponent<ICameraMove>();
        cameraZoomer = GetComponent<ICameraZoom>();
        cameraShaker = GetComponentInChildren<ICameraShake>();

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

        player1DamageSubject?.Remove(this);
        player2DamageSubject?.Remove(this);
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

    public void OnNotify(DecrementHealthEventArgs parameter)
    {
        StartCoroutine(cameraShaker.ShakeRoutine());
    }

    private void SetTargets(Transform[] targets)
    {
        this.targets = targets;
    }

    private void Setup(GameObject agent1Instace, GameObject agent2Instance)
    {
        player1DamageSubject = agent1Instace.GetComponent<ISubject<DecrementHealthEventArgs>>();
        player1DamageSubject.Add(this);

        player2DamageSubject = agent2Instance.GetComponent<ISubject<DecrementHealthEventArgs>>();
        player2DamageSubject.Add(this);
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