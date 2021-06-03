public class LeftHealthHUDBehaviour : HealthHUDBehaviourBase
{
    protected override void Awake()
    {
        healthSubject = GameManagerSingleton.Instance.Tank1Instance.GetComponent<ISubject<HealthArgs>>();
    }
}