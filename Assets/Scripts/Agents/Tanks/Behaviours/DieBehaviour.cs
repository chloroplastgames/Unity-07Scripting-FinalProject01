public class DieBehaviour : Subject<DieArgs>, IKillable
{
    public void Kill()
    {
        Notify();
    }

    public override void Notify()
    {
        IObserver<DieArgs>[] observersPhoto = observers.ToArray();

        foreach(IObserver<DieArgs> observer in observersPhoto)
        {
            observer.OnNotify(new DieArgs());
        }
    }
}