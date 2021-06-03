public class RightHealthHUDBehaviour : HealthHUDBehaviourBase
{
    protected override void Awake()
    {
        healthSubject = GameManagerSingleton.Instance.Tank2Instance.GetComponent<ISubject<HealthArgs>>();
    }
}