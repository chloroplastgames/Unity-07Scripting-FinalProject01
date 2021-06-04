public class LeftHealthHUDBehaviour : HealthHUDBehaviourBase
{
    protected override void Awake()
    {
        healthSubject = GameManagerSingleton.Instance.Agent1Instance.GetComponent<ISubject<HealthChangedArgs>>();
    }
}