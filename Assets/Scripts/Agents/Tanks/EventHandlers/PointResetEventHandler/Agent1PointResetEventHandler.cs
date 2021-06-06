public class Agent1PointResetEventHandler : PointResetEventHandlerBase
{
    protected override void ResetPoint()
    {
        transform.SetPositionAndRotation(gameController.SpawnPoint1.position, gameController.SpawnPoint1.rotation);
    }
}