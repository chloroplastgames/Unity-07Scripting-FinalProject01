// TODO: Apply SOLID

using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] Targets {
        get
        {
            return targets;
        }
        set
        {
            targets = value;
        }
    }

    [SerializeField] private float dampTime = 0.2f;
    [SerializeField] private float screenEdgeBuffer = 4f;
    [SerializeField] private float minSize = 6.5f;
    [SerializeField] private Transform[] targets; // TODO: Remove SerializeField

    private Camera myCamera;
    private float zoomSpeed;
    private Vector3 moveVelocity;
    private Vector3 desiredPosition;

    private void Awake()
    {
        myCamera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        Move();

        Zoom();
    }

    public void ResetCamera()
    {
        FindAveragePositions();

        transform.position = desiredPosition;

        myCamera.orthographicSize = FindRequiredSize();
    }

    private void Move()
    {
        FindAveragePositions();

        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref moveVelocity, dampTime);
    }

    private void FindAveragePositions()
    {
        Vector3 averagePosition = new Vector3();
        int numTargets = 0;

        for (int i = 0; i < targets.Length; i++)
        {
            if (!targets[i].gameObject.activeSelf) continue;

            averagePosition += targets[i].position;
            numTargets++;
        }

        if (numTargets > 0) averagePosition /= numTargets;

        averagePosition.y = transform.position.y;

        desiredPosition = averagePosition;
    }

    private void Zoom()
    {
        float requiredSize = FindRequiredSize();
        myCamera.orthographicSize = Mathf.SmoothDamp(myCamera.orthographicSize, requiredSize, ref zoomSpeed, dampTime);
    }

    private float FindRequiredSize()
    {
        Vector3 desiredLocalPosition = transform.InverseTransformPoint(desiredPosition);

        float size = 0f;

        for (int i = 0; i < targets.Length; i++)
        {
            if (!targets[i].gameObject.activeSelf) continue;

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