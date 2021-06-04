public class RightBackgroundHUDBehaviour : BackgroundHUDBehaviourBase
{
    protected override void OnEnable()
    {
        background.color = GameManagerSingleton.Instance.Agent2Color;
    }
}