public class Agent2PointResetEventHandler : PointResetEventHandlerBase
{
    protected override void ResetPoint()
    {
        transform.SetPositionAndRotation(gameController.SpawnPoint2.position, gameController.SpawnPoint2.rotation);
    }
}