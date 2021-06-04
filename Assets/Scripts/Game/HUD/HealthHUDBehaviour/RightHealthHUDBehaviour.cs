public class RightHealthHUDBehaviour : HealthHUDBehaviourBase
{
    protected override void Awake()
    {
        healthSubject = GameManagerSingleton.Instance.Agent2Instance.GetComponent<ISubject<HealthChangedArgs>>();
    }
}