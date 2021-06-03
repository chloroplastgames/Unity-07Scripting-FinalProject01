public class LeftPointsHUDBehaviour : PointsHUDBehaviourBase
{
    protected override void Awake()
    {
        pointsSubject = GameManagerSingleton.Instance.Player1RoundWinner;
    }

    protected override void OnEnable()
    {
        base.OnEnable();

        UpdatePointsText(GameManagerSingleton.Instance.Tank1Wins); // TODO: redundancy
    }
}