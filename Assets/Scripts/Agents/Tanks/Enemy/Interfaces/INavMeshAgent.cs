public interface INavMeshAgent
{
    float RemainingDistance { get; }
    bool CanSetDestinationInsideCircle(int min, int max);
    void Stop();
    void Resume();
}