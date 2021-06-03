using UnityEngine;

public class GameplayCameraController : MonoBehaviour
{
    public Transform[] Targets { get => targets; set => targets = value; }

    private Transform[] targets;
    private ICameraMove cameraMover;
    private ICameraZoom cameraZoomer;

    private void Awake()
    {
        cameraMover = GetComponent<ICameraMove>();
        cameraZoomer = GetComponent<ICameraZoom>();
    }

    private void LateUpdate()
    {
        cameraMover.MoveCamera(targets);
        cameraZoomer.ZoomCamera(targets, cameraMover.FindAveragePosition(targets));
    }

    public void ResetCamera()
    {
        cameraMover.ResetPosition(targets);
        cameraZoomer.ResetZoom(targets, cameraMover.FindAveragePosition(targets));
    }
}