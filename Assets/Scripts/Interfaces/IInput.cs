using UnityEngine;

public interface IInput
{
    Vector3 GetDirection();

    void Enable();

    void Disable();
}
