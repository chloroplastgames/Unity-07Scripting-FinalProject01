public interface ISetupHealthHUD
{
    void Setup(ISubject<HealthChangedArgs> healthSubject);
}