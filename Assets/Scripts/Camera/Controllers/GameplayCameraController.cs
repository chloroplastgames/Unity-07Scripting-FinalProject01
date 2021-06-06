using UnityEngine;

public class GameplayCameraController : MonoBehaviour,
    IObserver<SetupGameEventArgs>,
    IObserver<StartRoundEventArgs>,
    IObserver<GameWinnerEventArgs>,
    IObserver<ButtonRestartEventArgs>
{
    private Transform[] targets;
    private ICameraMove cameraMover;
    private ICameraZoom cameraZoomer;

    GameController gameController;
    IGameOverEvents gameOverEvents;

    private Vector3 initialPosition;
    private bool isFixed;

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
    }

    public void OnNotify(SetupGameEventArgs setupGameArgs)
    {
        SetTargets(new Transform[] { setupGameArgs.agent1Instance.transform, setupGameArgs.agent2Instance.transform });
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

    private void SetTargets(Transform[] targets)
    {
        this.targets = targets;
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