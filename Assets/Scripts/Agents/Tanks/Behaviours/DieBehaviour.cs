public class DieBehaviour : Subject<DieArgs>, IKillable
{
    public void Kill()
    {
        Notify();
    }

    public override void Notify()
    {
        for (int i = 0; i < observers.Count; i++)
        {
            IObserver<DieArgs> observer = observers[i];
            observer.OnNotify(new DieArgs());
        }
    }
}