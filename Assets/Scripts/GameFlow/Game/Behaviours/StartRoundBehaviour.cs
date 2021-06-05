public class StartRoundBehaviour : Subject<StartRoundEventArgs>
{
    public void StartRound()
    {
        Notify();
    }
    public override void Notify()
    {
        IObserver<StartRoundEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<StartRoundEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new StartRoundEventArgs());
        }
    }
}