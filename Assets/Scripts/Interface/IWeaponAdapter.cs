using UnityEngine;

public interface IWeaponAdapter
{
    void Fire(IInput inputs);

    void SetupPosition(Tank tank);

    GameObject Weapon();
}
