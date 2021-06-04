public class LeftBackgroundHUDBehaviour : BackgroundHUDBehaviourBase
{
    protected override void OnEnable()
    {
        background.color = GameManagerSingleton.Instance.Agent1Color;
    }
}