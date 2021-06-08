using UnityEngine;

public interface ICameraZoom
{
    void ZoomCamera(Transform[] targets, Vector3 position);
    void ResetZoom(Transform[] targets, Vector3 position);
}