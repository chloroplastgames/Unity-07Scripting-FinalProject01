public class DieBehaviour : Subject<DieEventArgs>, IKillable
{
    public void Kill()
    {
        Notify();
    }

    public override void Notify()
    {
        IObserver<DieEventArgs>[] observersPhoto = observers.ToArray();

        foreach(IObserver<DieEventArgs> observer in observersPhoto)
        {
            observer.OnNotify(new DieEventArgs());
        }
    }
}