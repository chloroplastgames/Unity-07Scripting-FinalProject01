public class Player2RoundWinnerBehaviour : Subject<PointsArg>
{
    private int points;

    public override void Notify()
    {
        IObserver<PointsArg>[] observersPhoto = observers.ToArray();

        foreach (IObserver<PointsArg> observer in observersPhoto)
        {
            observer.OnNotify(new PointsArg(points));
        }
    }

    public bool HasPlayer2WonRound(int player1Health, int player2Health)
    {
        if (player1Health == 0 || player2Health > player1Health)
        {
            points++;
            Notify();
            return true;
        }

        return false;
    }

    public void ResetPoints()
    {
        points = 0;

        Notify();
    }
}