using UnityEngine;

public interface ICameraMove
{
    void MoveCamera(Transform[] targets);
    void ResetPosition(Transform[] targets);
    Vector3 FindAveragePosition(Transform[] targets);
}