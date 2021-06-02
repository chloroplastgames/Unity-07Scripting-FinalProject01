using UnityEngine;

public interface IInput
{
    Vector2 GetMotionDirection();

    bool GetPrimaryFire();

    bool GetSecundaryFire();
}
