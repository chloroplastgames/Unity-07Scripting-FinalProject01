// TODO: get round winner, get game winner?

public class EndRoundBehaviour : Subject<EndRoundEventArgs>
{
    public void EndRound()
    {

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