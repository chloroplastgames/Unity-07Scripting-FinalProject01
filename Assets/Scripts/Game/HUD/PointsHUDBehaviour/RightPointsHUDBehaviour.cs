public class RightPointsHUDBehaviour : PointsHUDBehaviourBase
{
    protected override void Awake()
    {
        pointsSubject = GameManagerSingleton.Instance.Player2RoundWinner;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        UpdatePointsText(GameManagerSingleton.Instance.Agent2Wins);
    }
}