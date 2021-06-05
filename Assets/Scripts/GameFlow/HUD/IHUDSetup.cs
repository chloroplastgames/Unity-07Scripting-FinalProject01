public interface IHUDSetup
{
    void SetupLeftHealthHUD(ISubject<HealthChangedArgs> healthSubject);
    void SetupRightHealthHUD(ISubject<HealthChangedArgs> healthSubject);
}