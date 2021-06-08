
// Behaviour to notify about round end
public class EndRoundBehaviour : Subject<EndRoundEventArgs>
{
    public void EndRound()
    {
        Notify();
    }

    public override void Notify()
    {
        IObserver<EndRoundEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<EndRoundEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new EndRoundEventArgs());
        }
    }
}