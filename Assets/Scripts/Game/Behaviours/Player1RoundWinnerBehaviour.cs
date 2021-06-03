public class Player1RoundWinnerBehaviour : Subject<PointsArg>
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

    public bool HasPlayer1WonRound(int player1Health, int player2Health)
    {
        if (player2Health == 0 || player1Health > player2Health)
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