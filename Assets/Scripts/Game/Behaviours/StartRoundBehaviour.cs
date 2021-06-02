public class StartRoundBehaviour : Subject<StartRoundArgs>, IStartRound
{
    public void StartRound()
    {
        Notify();
    }

    public override void Notify()
    {
        IObserver<StartRoundArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<StartRoundArgs> observer in observersPhoto)
        {
            observer.OnNotify(new StartRoundArgs());
        }
    }
}