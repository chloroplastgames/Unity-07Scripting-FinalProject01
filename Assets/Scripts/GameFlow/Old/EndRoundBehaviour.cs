public class EndRoundBehaviour : Subject<EndRoundArgs>, IEndRound
{
    public void EndRound()
    {
        Notify();
    }

    public override void Notify()
    {
        IObserver<EndRoundArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<EndRoundArgs> observer in observersPhoto)
        {
            observer.OnNotify(new EndRoundArgs());
        }
    }
}