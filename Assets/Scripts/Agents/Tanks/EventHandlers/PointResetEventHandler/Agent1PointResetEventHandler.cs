public class Agent1PointResetEventHandler : PointResetEventHandlerBase
{
    protected override void ResetPoint()
    {
        leftDustTrail.SetActive(false);
        rightDustTrail.SetActive(false);

        transform.SetPositionAndRotation(gameController.SpawnPoint1.position, gameController.SpawnPoint1.rotation);

        leftDustTrail.SetActive(true);
        leftDustTrail.SetActive(true);
    }
}