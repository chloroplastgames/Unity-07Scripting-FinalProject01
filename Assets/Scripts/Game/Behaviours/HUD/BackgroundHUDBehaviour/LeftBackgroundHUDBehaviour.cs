public class LeftBackgroundHUDBehaviour : BackgroundHUDBehaviourBase
{
    protected override void OnEnable()
    {
        background.color = GameManagerSingleton.Instance.Tank1Color;
    }
}