public class GameWinnerBehaviour : Subject<GameWinnerEventArgs>
{
    public GameWinner GameWinner
    {
        get
        {
            return gameWinner;
        }
        set
        {
            gameWinner = value;
            Notify();
        }
    }

    private GameWinner gameWinner;

    public override void Notify()
    {
        IObserver<GameWinnerEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<GameWinnerEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new GameWinnerEventArgs(gameWinner));
        }
    }
}