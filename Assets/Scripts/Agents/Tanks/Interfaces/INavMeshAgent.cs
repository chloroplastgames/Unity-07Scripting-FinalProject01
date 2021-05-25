public interface INavMeshAgent
{
    bool CanSetDestinationInsideCircle(int min, int max);
    void Stop();
    void Resume();
    float GetRemainingDistance();
}