public interface IWeaponController
{
    void ChangeWeapon(IWeapon NewWeapon);

    void SecundaryFire(IInput input);

    void PrimaryFire(IInput input);
}
