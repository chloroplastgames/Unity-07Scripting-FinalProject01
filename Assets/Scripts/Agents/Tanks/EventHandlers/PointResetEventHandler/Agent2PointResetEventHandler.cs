public class Agent2PointResetEventHandler : PointResetEventHandlerBase
{
    protected override void ResetPoint()
    {
        leftDustTrail.SetActive(false);
        rightDustTrail.SetActive(false);

        transform.SetPositionAndRotation(gameController.SpawnPoint2.position, gameController.SpawnPoint2.rotation);

        leftDustTrail.SetActive(true);
        leftDustTrail.SetActive(true);
    }
}