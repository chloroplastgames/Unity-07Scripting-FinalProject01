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

    private void OnEnable()
    {
        gameController.SetupGameSubject.Add(this);
        gameController.SetupRoundSubject.Add(this);
    }

    private void LateUpdate()
    {
        if (targets == null) return;

        cameraMover.MoveCamera(targets);
        cameraZoomer.ZoomCamera(targets, cameraMover.FindAveragePosition(targets));
    }

    private void OnDisable()
    {
        gameController.SetupGameSubject.Remove(this);
        gameController.SetupRoundSubject.Remove(this);
    }

    public void OnNotify(SetupGameEventArgs setupGameArgs)
    {
        targets = new Transform[] { setupGameArgs.agent1Instance.transform, setupGameArgs.agent2Instance.transform };
    }

    public void OnNotify(StartRoundEventArgs parameter)
    {
        ResetCamera();
    }

    private void ResetCamera()
    {
        cameraMover.ResetPosition(targets);
        cameraZoomer.ResetZoom(targets, cameraMover.FindAveragePosition(targets));
    }
}