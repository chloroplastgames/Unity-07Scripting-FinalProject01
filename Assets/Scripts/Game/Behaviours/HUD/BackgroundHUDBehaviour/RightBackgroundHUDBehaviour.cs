public class RightBackgroundHUDBehaviour : BackgroundHUDBehaviourBase
{
    protected override void OnEnable()
    {
        background.color = GameManagerSingleton.Instance.Tank2Color;
    }
}