using UnityEngine;

public class CameraZoomBehaviour : MonoBehaviour, ICameraZoom
{
    [SerializeField] private float dampTime = 0.2f;
    [SerializeField] private float screenEdgeBuffer = 4f;
    [SerializeField] private float minSize = 6.5f;

    private Camera myCamera;
    private float zoomSpeed;

    private void Awake()
    {
        myCamera = GetComponentInChildren<Camera>();
    }

    public void ResetZoom(Transform[] targets, Vector3 averagePosition)
    {
        myCamera.orthographicSize = FindRequiredSize(targets, averagePosition);
    }

    public void ZoomCamera(Transform[] targets, Vector3 averagePosition)
    {
        float requiredSize = FindRequiredSize(targets, averagePosition);
        myCamera.orthographicSize = Mathf.SmoothDamp(myCamera.orthographicSize, requiredSize, ref zoomSpeed, dampTime);
    }

    private float FindRequiredSize(Transform[] targets, Vector3 averagePosition)
    {
        Vector3 desiredLocalPosition = transform.InverseTransformPoint(averagePosition);

        float size = 0f;

        for (int i = 0; i < targets.Length; i++)
        {
            Vector3 targetLocalPosition = transform.InverseTransformPoint(targets[i].position);

            Vector3 desiredPositionToTarget = targetLocalPosition - desiredLocalPosition;

            size = Mathf.Max(size, Mathf.Abs(desiredPositionToTarget.y));

            size = Mathf.Max(size, Mathf.Abs(desiredPositionToTarget.x) / myCamera.aspect);
        }

        size += screenEdgeBuffer;

        size = Mathf.Max(size, minSize);

        return size;
    }
}