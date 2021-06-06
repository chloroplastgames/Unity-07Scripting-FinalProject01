public class CancelCharacterSelectionBehaviour : Subject<CancelEventArgs>
{
    public void CancelSelection()
    {
        Notify();
    }

    public override void Notify()
    {
        IObserver<CancelEventArgs>[] observersPhoto = observers.ToArray();

        foreach (IObserver<CancelEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new CancelEventArgs());
        }
    }
}