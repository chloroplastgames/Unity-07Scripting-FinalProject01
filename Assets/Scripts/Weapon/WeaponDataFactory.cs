using UnityEngine;

public sealed class WeaponDataFactory:MonoBehaviour
{
    public PrimaryWeapon Weapon;

    public Cannon Cannon;

    public  IWeaponAdapter GetPrimaryWeapon()
    {
        return Instantiate(Weapon);
    }

    public IWeaponAdapter GetCannon()
    {
        return Instantiate(Cannon);
    }
}
