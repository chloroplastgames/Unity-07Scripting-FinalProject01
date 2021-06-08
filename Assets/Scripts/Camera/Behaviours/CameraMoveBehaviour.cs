using UnityEngine;

public class CameraMoveBehaviour : MonoBehaviour, ICameraMove
{
    [SerializeField] private float dampTime = 0.2f;

    private Vector3 moveVelocity;

    public void ResetPosition(Transform[] targets)
    {
        transform.position = FindAveragePosition(targets);
    }

    public void MoveCamera(Transform[] targets)
    {
        FindAveragePosition(targets);

        transform.position = Vector3.SmoothDamp(transform.position, FindAveragePosition(targets), ref moveVelocity, dampTime);
    }

    public Vector3 FindAveragePosition(Transform[] targets)
    {
        Vector3 averagePosition = new Vector3();
        int numTargets = 0;

        for (int i = 0; i < targets.Length; i++)
        {
            averagePosition += targets[i].position;
            numTargets++;
        }

        if (numTargets > 0) averagePosition /= numTargets;

        averagePosition.y = transform.position.y;

        return averagePosition;
    }
}