
// Behaviour to notify the left hud about points
public class Agent1PointsBehaviour : Subject<PointsEventArgs>
{
    private int points;

    private void Start()
    {
        ResetPoints();
    }

    public int IncrementPoints()
    {
        points++;

        Notify();

        return points;
    }

    public void ResetPoints()
    {
        points = 0;

        Notify();
    }

    public override void Notify()
    {
        IObserver<PointsEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<PointsEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new PointsEventArgs(points));
        }
    }
}