using UnityEngine;

public class GameplayCameraController : MonoBehaviour, IObserver<SetupGameEventArgs>, IObserver<StartRoundEventArgs>
{
    private Transform[] targets;
    private ICameraMove cameraMover;
    private ICameraZoom cameraZoomer;

    GameController gameController;

    private void Awake()
    {
        cameraMover = GetComponent<ICameraMove>();
        cameraZoomer = GetComponent<ICameraZoom>();

        gameController = FindObjectOfType<GameController>();
    }

    private void Start()
    {
        gameController.SetupGameSubject.Add(this);
        gameController.StartRoundSubject.Add(this);
    }

    private void LateUpdate()
    {
        if (targets == null) return;

        cameraMover.MoveCamera(targets);
        cameraZoomer.ZoomCamera(targets, cameraMover.FindAveragePosition(targets));
    }

    private void OnDestroy()
    {
        gameController.SetupGameSubject?.Remove(this);
        gameController.StartRoundSubject?.Remove(this);
    }

    public void OnNotify(SetupGameEventArgs setupGameArgs)
    {
        SetTargets(new Transform[] { setupGameArgs.agent1Instance.transform, setupGameArgs.agent2Instance.transform });
    }

    public void OnNotify(StartRoundEventArgs parameter)
    {
        ResetCamera();
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
}