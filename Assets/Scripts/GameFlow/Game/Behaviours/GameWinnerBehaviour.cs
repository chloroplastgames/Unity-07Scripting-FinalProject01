using UnityEngine;

public class GameWinnerBehaviour : Subject<GameWinnerEventArgs>
{
    public GameWinner GameWinner
    {
        get
        {
            return GameWinner;
        }
        set
        {
            GameWinner = value;
            Notify();
        }
    }

    public override void Notify()
    {
        IObserver<GameWinnerEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<GameWinnerEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new GameWinnerEventArgs(GameWinner));
        }
    }
}