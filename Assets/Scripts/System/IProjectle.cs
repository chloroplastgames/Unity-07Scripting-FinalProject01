using UnityEngine;

public interface IProjectle
{
    void SetupDamage(float damage);

    void SetupDirection(Vector3 direction);

    void Enable();

    void Disable();

    Transform GetTransform();
}
